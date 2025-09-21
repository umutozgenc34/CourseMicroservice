using FluentValidation;

namespace CourseManagementSystemMicroservice.Payment.Api.Features.Payment.Create;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.OrderCode).NotEmpty().WithMessage("OrderCode is required.");
        RuleFor(x => x.CardNumber).NotEmpty().WithMessage("CardNumber is required.");
        RuleFor(x => x.CardHolderName).NotEmpty().WithMessage("CardHolderName is required.");
        RuleFor(x => x.CardExpirationDate).NotEmpty().WithMessage("CardExpirationDate is required.");
        RuleFor(x=> x.CardSecurityCode).NotEmpty().WithMessage("CardSecurityCode is required.");
        RuleFor(x => x.amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");

    }
}
