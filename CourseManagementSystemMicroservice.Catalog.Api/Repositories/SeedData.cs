using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CourseManagementSystemMicroservice.Catalog.Api.Repositories;

public static class SeedData
{
    public static async Task AddSeedDataExtension(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BaseDbContext>();

        context.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

        if (!context.Categories.Any())
        {
            var categories = new List<Category>
            {
                    new() { Id = NewId.NextSequentialGuid(), Name = "Web" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "DevOps" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Game Development" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Cyber Security" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "UI/UX" }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }

        if (!context.Courses.Any())
        {
            var category = await context.Categories.FirstAsync();
            var randomUserId = NewId.NextGuid();

            List<Course> courses =
            [
                new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "C#",
                        Description = "Temel seviye C# Kursu",
                        Price = 100,
                        UserId = randomUserId,
                        Created = DateTime.UtcNow,
                        Feature = new Feature { Duration = 5, Rating = 5, EducatorFullName = "Fatih Çakıroğlu" },
                        CategoryId = category.Id
                    },

                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Java",
                        Description = "Java Spring Kursu",
                        Price = 200,
                        UserId = randomUserId,
                        Created = DateTime.UtcNow,
                        Feature = new Feature { Duration = 8, Rating = 5, EducatorFullName = "Fatih Çakıroğlu" },
                        CategoryId = category.Id
                    },

                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = ".Net Core",
                        Description = "İleri Seviye .Net Core Kursu",
                        Price = 10,
                        UserId = randomUserId,
                        Created = DateTime.UtcNow,
                        Feature = new Feature { Duration = 10, Rating = 5, EducatorFullName = "Fatih Çakıroğlu" },
                        CategoryId = category.Id
                    }
            ];


            await context.Courses.AddRangeAsync(courses);
            await context.SaveChangesAsync();
        }
    }
}

