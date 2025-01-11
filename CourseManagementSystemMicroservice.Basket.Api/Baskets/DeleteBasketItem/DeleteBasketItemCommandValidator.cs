using FluentValidation;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.DeleteBasketItem;

public class DeleteBasketItemCommandValidator : AbstractValidator<DeleteBasketItemCommand>
{
    public DeleteBasketItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
