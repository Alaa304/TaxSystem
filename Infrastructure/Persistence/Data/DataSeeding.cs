using System.Text.Json;
using Core.Domain.Entities;
using Microsoft.Extensions.Logging;
using Presistence.Data;

namespace Infrastructure.Persistence.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(TaxDbContext context, ILogger logger)
        {
            try
            {
                var basePath = @"F:\P_G\TaxSystem\Infrastructure\Persistence\Data\DataSeeding\";

                // ===== Shaikhas =====
                if (!context.Shaikhas.Any())
                {
                    var data = await File.ReadAllTextAsync(Path.Combine(basePath, "shaikhas.json"));
                    var items = JsonSerializer.Deserialize<List<Shaikha>>(data);
                    context.Shaikhas.AddRange(items!);
                    await context.SaveChangesAsync();
                }

                // ===== Streets =====
                if (!context.Streets.Any())
                {
                    var data = await File.ReadAllTextAsync(Path.Combine(basePath, "streets.json"));
                    var items = JsonSerializer.Deserialize<List<Street>>(data)!;

                    // تحقق من أن ShaikhaId موجود في DB
                    var validShaikhaIds = context.Shaikhas.Select(s => s.Id).ToHashSet();
                    items = items.Where(s => validShaikhaIds.Contains(s.ShaikhaId)).ToList();

                    context.Streets.AddRange(items);
                    await context.SaveChangesAsync();
                }

                // ===== Properties =====
                if (!context.Properties.Any())
                {
                    var data = await File.ReadAllTextAsync(Path.Combine(basePath, "properties.json"));
                    var items = JsonSerializer.Deserialize<List<Property>>(data)!;

                    // تحقق من StreetId
                    var validStreetIds = context.Streets.Select(s => s.Id).ToHashSet();
                    items = items.Where(p => validStreetIds.Contains(p.StreetId)).ToList();

                    context.Properties.AddRange(items);
                    await context.SaveChangesAsync();
                }
// ===== Units =====
if (!context.Units.Any())
{
    var data = await File.ReadAllTextAsync(Path.Combine(basePath, "units.json"));

    // إعدادات تحويل الـ String إلى Enum
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

    // Deserialize مع تحويل الـ Strings للـ Enum
    var items = JsonSerializer.Deserialize<List<Unit>>(data, options)!;

    // تحقق من PropertyId
    var validPropertyIds = context.Properties.Select(p => p.Id).ToHashSet();
    items = items.Where(u => validPropertyIds.Contains(u.PropertyId)).ToList();

    context.Units.AddRange(items);
    await context.SaveChangesAsync();
}


                // ===== Persons =====
                if (!context.Persons.Any())
                {
                    var data = await File.ReadAllTextAsync(Path.Combine(basePath, "persons.json"));
                    var items = JsonSerializer.Deserialize<List<Person>>(data)!;
                    context.Persons.AddRange(items);
                    await context.SaveChangesAsync();
                }

                // ===== RoleAssignments =====
                if (!context.RoleAssignments.Any())
                {
                    var data = await File.ReadAllTextAsync(Path.Combine(basePath, "roleAssignments.json"));
                    var items = JsonSerializer.Deserialize<List<RoleAssignment>>(data)!;

                    // تحقق من PersonId و UnitId
                    var validPersonIds = context.Persons.Select(p => p.Id).ToHashSet();
                    var validUnitIds = context.Units.Select(u => u.Id).ToHashSet();
                    items = items.Where(r => validPersonIds.Contains(r.PersonId) && validUnitIds.Contains(r.UnitId)).ToList();

                    context.RoleAssignments.AddRange(items);
                    await context.SaveChangesAsync();
                }

                logger.LogInformation("Database seeded successfully ✔");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error seeding the database ❌");
            }
        }
    }
}
