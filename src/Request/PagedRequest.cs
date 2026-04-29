namespace apiExemplo.src.Requests;

public class PagedRequest
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string OrderBy { get; set; } = string.Empty;
    public string Sort { get; set; }  = string.Empty;
    public string UserToken { get; set; }  = string.Empty;
}