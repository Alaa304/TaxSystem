using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Infrastructure.Persistence.Seed;
using Infrastructure.Mapping;
using Core;
using Infrastructure.Services;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // <-- هنا

// AutoMapper
builder.Services.AddAutoMapper(typeof(PersonProfile), typeof(UnitProfile));

// DI Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IUnitService, UnitService>();

// DbContext
builder.Services.AddDbContext<TaxDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Data seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<TaxDbContext>();
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("DbSeeder");

    await DbSeeder.SeedAsync(dbContext, logger);
}

app.Run();
