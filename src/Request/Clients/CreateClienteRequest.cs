namespace apiExemplo.src.Requests.Cliente;

public class CreateClienteRequest : Request
{
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Bairro { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public string CEP { get; set; } = string.Empty;
    public decimal ValorCredito { get; set; }
    public int QuantidadeFuncionarios { get; set; } = 0;
    public DateTime DataCliente { get; set; } = DateTime.MinValue;
    public bool Ativo { get; set; } = false;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public bool Deletado { get; set; } = false;
}