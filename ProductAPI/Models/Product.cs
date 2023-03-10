using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductAPI.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }
        public string? Picture { get; set; }
        public string? ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category? Category { get; set; }
        public string? Description { get; set; }
    }
}
