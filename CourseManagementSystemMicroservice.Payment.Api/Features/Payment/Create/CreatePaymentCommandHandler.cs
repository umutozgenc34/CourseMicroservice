using CourseManagementSystemMicroservice.Payment.Api.Repositories;
using CourseManagementSystemMicroservice.Shared;
using CourseManagementSystemMicroservice.Shared.Services;
using MediatR;

namespace CourseManagementSystemMicroservice.Payment.Api.Features.Payment.Create;

public class CreatePaymentCommandHandler(AppDbContext context,IIdentityService identityService) : 
    IRequestHandler<CreatePaymentCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
       var(isSuccess, errorMessage) = await ExternalPaymentProcessAsync(request.CardNumber, request.CardHolderName,
            request.CardExpirationDate, request.CardSecurityCode, request.amount);

        if (!isSuccess)
            return ServiceResult.Error("Payment failed.", errorMessage!,System.Net.HttpStatusCode.BadRequest);

        var userId = identityService.GetUserId;
        var newPayment = new Repositories.Payment(userId,request.OrderCode,request.amount);
        newPayment.SetStatus(PaymentStatus.Success);

        context.Payments.Add(newPayment);
        await context.SaveChangesAsync(cancellationToken);
        return ServiceResult.SuccessAsNoContent();
    }

    private async Task<(bool isSuccess,string? errorMessage)> ExternalPaymentProcessAsync(string cardNumber,string cardHolderName,
        string cardExpirationDate,string cardSecurityNumber,decimal amount)
    {
        await Task.Delay(1000);
        return (true,null);
    }
}
