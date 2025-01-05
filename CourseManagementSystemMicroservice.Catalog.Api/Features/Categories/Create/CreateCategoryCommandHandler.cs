using CourseManagementSystemMicroservice.Catalog.Api.Repositories;
using CourseManagementSystemMicroservice.Shared;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
{
    private readonly BaseDbContext _context;
    public CreateCategoryCommandHandler(BaseDbContext context)
    {
        _context = context;
    }
    public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var anyCategory = await _context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);
        if (anyCategory)
        {
            ServiceResult<CreateCategoryResponse>.Error("Category name already exists.", $"Category : {request.Name}",HttpStatusCode.BadRequest);
        }

        var category = new Category
        {
            Name = request.Name,
            Id = NewId.NextSequentialGuid() // id benzer olması için - daha rahat indexleme yapılabilir
        };

        await _context.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var categoryAsResponse = new CreateCategoryResponse(category.Id);
        
        return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(categoryAsResponse,"empty");
    }
}
