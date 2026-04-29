using MongoDB.Bson.Serialization.Attributes;

namespace apiExemplo.src.Models
{
    public class ModelBase
    {
        [BsonElement("ativo")]
        public bool Ativo { get; set; }

        [BsonElement("deletedo")]
        public bool Deletedo { get; set; }

        [BsonElement("dataCadastro")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}