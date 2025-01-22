using CourseManagementSystemMicroservice.Discount.Api.Options;
using MongoDB.Driver;

namespace CourseManagementSystemMicroservice.Discount.Api.Repositories;

public static class RepositoryExtensions
{
    public static IServiceCollection AddDatabaseServiceExtensions(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            var options = sp.GetRequiredService<MongoOption>();
            return new MongoClient(options.ConnectionString);
        });

        services.AddScoped(sp =>
        {
            var mongoClient = sp.GetRequiredService<IMongoClient>();
            var options = sp.GetRequiredService<MongoOption>();

            return BaseDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
        });


        return services;
    }
}
