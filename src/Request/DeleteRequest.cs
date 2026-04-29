using Microsoft.Extensions.Primitives;

namespace apiExemplo.src.Requests;

public class DeleteRequest : Request
{
    public DeleteRequest() { }
    public DeleteRequest(string id, HttpContext httpContext) { 
        UserId = httpContext.User.FindFirst("id")?.Value ?? "";
        StringValues? authorization = httpContext.Request?.Headers?.Authorization ?? [];
        if(authorization.HasValue && authorization?.Count > 0){
            string[] splitedValues = httpContext.Request?.Headers?.Authorization[0]?.Split(" ") ?? [];
            UserToken = splitedValues.Length > 1 ? splitedValues[1] : "";
        }
        Id = id;
    }
    public string Id { get; set; } = string.Empty;
}