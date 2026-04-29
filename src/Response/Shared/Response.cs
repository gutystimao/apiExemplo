using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace apiExemplo.src.Response.Shared
{
public class Response<TData>
{
    private readonly int statusCode = Configuration.DefaultStatusCode;

    [JsonConstructor]
    public Response(Models.User usuario) => statusCode = Configuration.DefaultStatusCode;

    public Response(string message){
        statusCode = 400;
        Message = message;    
    }

    public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null, string? logEvent = null, dynamic? initialData = null)
    {
        Data = data;
        statusCode = code;
        Message = message;
        LogEvent = logEvent ?? "";
        InitialData = initialData;
    }

    public TData? Data { get; set; }
    
    public string? Message { get; set; }

    [JsonIgnore]
    public string LogEvent { get; set; } = string.Empty;

    [JsonIgnore]
    public dynamic? InitialData { get; set; }

    [JsonIgnore]
    public bool IsSuccess => statusCode is >= 200 and <= 299;
    
    [JsonIgnore]
    public virtual dynamic Result => new{
        Message,
        Data
    };
}
}