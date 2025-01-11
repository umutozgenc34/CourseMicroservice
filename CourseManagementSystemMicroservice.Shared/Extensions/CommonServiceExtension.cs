using CourseManagementSystemMicroservice.Shared.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CourseManagementSystemMicroservice.Shared.Extensions;

public static class CommonServiceExtension
{
    public static IServiceCollection AddCommonServiceExtension(this IServiceCollection services,Type assembly)
    {
        services.AddHttpContextAccessor();
        services.AddMediatR(x=> x.RegisterServicesFromAssemblyContaining(assembly));
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);
        services.AddAutoMapper(assembly);

        services.AddScoped<IIdentityService, IdentityServiceFake>();

        return services;
    }
}
