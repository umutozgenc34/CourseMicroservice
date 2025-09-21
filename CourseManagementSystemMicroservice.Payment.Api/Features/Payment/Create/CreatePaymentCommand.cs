using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.Payment.Api.Features.Payment.Create;

public record CreatePaymentCommand(string OrderCode, string CardNumber,string CardHolderName,
    string CardExpirationDate, string CardSecurityCode, decimal amount) : IRequestByServiceResult;

