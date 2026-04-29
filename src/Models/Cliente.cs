using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace apiExemplo.src.Models
{
    public class Cliente : ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("razaoSocial")]
        public string RazaoSocial { get; set; } = string.Empty;

        [BsonElement("nomeFantasia")]
        public string NomeFantasia { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("cnpj")]
        public string Cnpj { get; set; } = string.Empty;

        [BsonElement("logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        [BsonElement("numero")]
        public string Numero { get; set; } = string.Empty;

        [BsonElement("bairro")]
        public string Bairro { get; set; } = string.Empty;

        [BsonElement("cidade")]
        public string Cidade { get; set; } = string.Empty;

        [BsonElement("uf")]
        public string Uf { get; set; } = string.Empty;

        [BsonElement("cep")]
        public string Cep { get; set; } = string.Empty;

        [BsonElement("valorCredito")]
        public decimal ValorCredito { get; set; }

        [BsonElement("quantidadeFuncionarios")]
        public int QuantidadeFuncionarios { get; set; }

        [BsonElement("dataCliente")]
        public DateTime DataCliente { get; set; } = DateTime.MinValue;
    }
}