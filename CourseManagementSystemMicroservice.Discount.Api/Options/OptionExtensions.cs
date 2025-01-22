using Microsoft.Extensions.Options;

namespace CourseManagementSystemMicroservice.Discount.Api.Options;

public static class OptionExtensions
{
    public static IServiceCollection AddOptionExtensions(this IServiceCollection services)
    {
        services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();

        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);

        return services;

    }
}
