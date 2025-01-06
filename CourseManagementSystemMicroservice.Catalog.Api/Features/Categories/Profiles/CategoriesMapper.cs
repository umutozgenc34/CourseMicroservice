using AutoMapper;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Profiles;

public class CategoriesMapper : Profile
{
    public CategoriesMapper()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
