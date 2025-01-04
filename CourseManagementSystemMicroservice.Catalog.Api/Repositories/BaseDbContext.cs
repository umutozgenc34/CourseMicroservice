using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Reflection;

namespace CourseManagementSystemMicroservice.Catalog.Api.Repositories;

public class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }

    public static BaseDbContext Create(IMongoDatabase database)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<BaseDbContext>().UseMongoDB(database.Client,
                database.DatabaseNamespace.DatabaseName);


        return new BaseDbContext(optionsBuilder.Options);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            

        base.OnModelCreating(modelBuilder);
    }
}
