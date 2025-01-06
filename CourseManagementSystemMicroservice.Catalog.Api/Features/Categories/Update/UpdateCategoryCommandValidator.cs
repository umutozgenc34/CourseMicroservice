namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name be max length 50 characters.");
    }
}
