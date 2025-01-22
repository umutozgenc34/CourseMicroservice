using CourseManagementSystemMicroservice.Discount.Api.Features.Discounts;
using MongoDB.Driver;
using System.Reflection;

namespace CourseManagementSystemMicroservice.Discount.Api.Repositories;

public class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{
    public DbSet<Features.Discounts.Discount> Discounts { get; set; }
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
