using Asp.Versioning.Builder;
using CourseManagementSystemMicroservice.Payment.Api.Features.Payment.Create;

namespace CourseManagementSystemMicroservice.Payment.Api.Features.Payment;

public static class PaymentEndpointExt
{
    public static void AddPaymentGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/payment").WithTags("payments").WithApiVersionSet(apiVersionSet)
            .CreatePaymentGroupItemEndpoint();

    }
}
