using apiExemplo.src.Helpers;
using Microsoft.Extensions.Primitives;

namespace apiExemplo.src.Requests;

public class GetAllRequest : PagedRequest
{
    public GetAllRequest() { }
    public GetAllRequest(HttpContext httpContext) {
        QueryParams = Helper.NormalizeQueryParams(httpContext.Request.Query);
        StringQueryParams = httpContext.Request.QueryString.ToString();
        StringValues? authorization = httpContext.Request?.Headers?.Authorization ?? [];
        if(authorization.HasValue && authorization?.Count > 0){
            string[] splitedValues = httpContext.Request?.Headers?.Authorization[0]?.Split(" ") ?? [];
            UserToken = splitedValues.Length > 1 ? splitedValues[1] : "";
        }
     }
    public Dictionary<string, string> QueryParams { get; set; } = [];

    public string StringQueryParams { get; set; } = string.Empty;
}


