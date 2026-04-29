
namespace apiExemplo.src.Requests.User;
public class CreateUserRequest : Request
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; } = DateTime.MinValue;
    public int Idade { get; set; } = 0;
    public string Cidade { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Permissoes { get; set; } = string.Empty;
    public bool Ativo { get; set; } = false;
    public bool Deletado { get; set; } = false;
    public DateTime DataCadastro { get; set; } = DateTime.MinValue;
}