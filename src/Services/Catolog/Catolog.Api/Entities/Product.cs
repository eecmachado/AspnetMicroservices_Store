using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catolog.Api.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("Name")] 
    public string Name { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageFile { get; set; }

    public decimal Price { get; set; }
}