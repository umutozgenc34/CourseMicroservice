using System.Text.Json.Serialization;

namespace CourseManagementSystemMicroservice.Basket.Api.Dtos;

public record BasketDto
{
    [JsonIgnore]
    public Guid UserId { get; init; }
    public List<BasketItemDto> Items { get; init; } = new();

    public BasketDto(Guid userId,List<BasketItemDto> items)
    {
        UserId = userId;
        Items = items;
    }

    public BasketDto()
    {
        
    }
}


