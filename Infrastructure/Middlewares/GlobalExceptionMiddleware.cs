using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.DTOs;

namespace Infrastructure.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (BusinessRuleException ex)
            {
                await HandleBusinessRuleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleUnknownExceptionAsync(context, ex);
            }
        }

        private Task HandleValidationExceptionAsync(
            HttpContext context,
            FluentValidation.ValidationException exception)
        {
            _logger.LogWarning(exception, "Validation error");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var errors = exception.Errors
                .Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                })
                .ToList();

            var response = new
            {
                IsSuccess = false,
                StatusCode = context.Response.StatusCode,
                Message = "البيانات المرسلة غير صحيحة",
                Errors = errors
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private Task HandleBusinessRuleExceptionAsync(
            HttpContext context,
            BusinessRuleException exception)
        {
            _logger.LogInformation(exception, "Business rule violation");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var response = new
            {
                IsSuccess = false,
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private Task HandleUnknownExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new
            {
                IsSuccess = false,
                StatusCode = context.Response.StatusCode,
                Message = "حدث خطأ غير متوقع، يرجى المحاولة لاحقًا"
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message) { }
    }
}
