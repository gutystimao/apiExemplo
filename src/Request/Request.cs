namespace apiExemplo.src.Requests;

public abstract class Request
{
    public string UserId { get; set; } = string.Empty;
    public string ClienteId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
    public string UserToken { get; set; } = string.Empty;
}