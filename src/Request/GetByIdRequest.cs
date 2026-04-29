using Microsoft.Extensions.Primitives;

namespace apiExemplo.src.Requests;

public class GetByIdRequest : Request
{
    public GetByIdRequest() { }
    public GetByIdRequest(string id) { 
        Id = id;
    }

    public GetByIdRequest(string id, HttpContext httpContext) {
        Id = id; 
        StringValues? authorization = httpContext.Request?.Headers?.Authorization ?? [];
        if(authorization.HasValue && authorization?.Count > 0){
            string[] splitedValues = httpContext.Request?.Headers?.Authorization[0]?.Split(" ") ?? [];
            UserToken = splitedValues.Length > 1 ? splitedValues[1] : "";
        }
    }
    public string Id { get; set; } = string.Empty;
}

