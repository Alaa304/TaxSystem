using FluentValidation;
using Shared.DTOs.SystemLog;

namespace Core.Validators.SystemLog
{
    /// <summary>
    /// Validator اختياري للتحقق من البيانات قبل الإرجاع
    /// </summary>
    public class SystemLogResponseDtoValidator : AbstractValidator<SystemLogResponseDto>
    {
        public SystemLogResponseDtoValidator()
        {
            RuleFor(x => x.LogID)
                .GreaterThan(0)
                .WithMessage("رقم السجل غير صحيح");

            RuleFor(x => x.TableName)
                .NotEmpty()
                .WithMessage("اسم الجدول مطلوب")
                .MaximumLength(50)
                .WithMessage("اسم الجدول يجب ألا يزيد عن 50 حرف");

            RuleFor(x => x.ActionType)
                .NotEmpty()
                .WithMessage("نوع العملية مطلوب")
                .MaximumLength(30)
                .WithMessage("نوع العملية يجب ألا يزيد عن 30 حرف");

            RuleFor(x => x.ActionDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("تاريخ العملية غير صالح");
        }
    }
}
