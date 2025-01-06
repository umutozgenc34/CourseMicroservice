namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>  
{
    public CreateCategoryCommandValidator()
    {
         RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name be max length 50 characters.");
    }
}
