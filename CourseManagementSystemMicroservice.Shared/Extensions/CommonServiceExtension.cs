using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CourseManagementSystemMicroservice.Shared.Extensions;

public static class CommonServiceExtension
{
    public static IServiceCollection AddCommonServiceExtension(this IServiceCollection services,Type assembly)
    {
        services.AddHttpContextAccessor();
        services.AddMediatR(x=> x.RegisterServicesFromAssemblyContaining(assembly));
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(assembly);

        return services;
    }
}
