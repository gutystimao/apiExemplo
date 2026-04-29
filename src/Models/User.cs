using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiExemplo.src.Models
{
    public class User : ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("dataNascimento")]
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;

        [BsonElement("cidade")]
        public string Cidade { get; set; } = string.Empty;

        [BsonElement("estado")]
        public string Estado { get; set; } = string.Empty;

        [BsonElement("idade")]
        public int Idade { get; set; }

        [BsonElement("permissoes")]
        public string Permissoes { get; set; } = string.Empty;
    }
}