using MongoDB.Bson.Serialization.Attributes;

namespace CourseManagementSystemMicroservice.Catalog.Api.Repositories;

public abstract class BaseEntity
{
    [BsonElement("_id")]
    public Guid Id { get; set; }
}
