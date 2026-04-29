using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiExemplo.src.Models
{
    public class Product : ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; } = string.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = string.Empty;

        [BsonElement("unitOfMeasure")]
        public string UnitOfMeasure { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("warehouse")]
        public string Warehouse { get; set; } = string.Empty;

        [BsonElement("stockQuantity")]
        public int StockQuantity { get; set; }

        [BsonElement("batch")]
        public string Batch { get; set; } = string.Empty;

        [BsonElement("expirationDate")]
        public DateTime ExpirationDate { get; set; } = DateTime.MinValue;

        [BsonElement("image")]
        public string Image { get; set; } = string.Empty;
    }
}