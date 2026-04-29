using apiExemplo.src.Common;
using apiExemplo.src.Helpers;
using apiExemplo.src.IHandlers;
using apiExemplo.src.Requests;
using apiExemplo.src.Requests.Cliente;
using apiExemplo.src.Requests.User;
using apiExemplo.src.Response.Shared;
using Microsoft.AspNetCore.Mvc;

namespace apiExemplo.src.Controllers
{
    [ApiController]
    public class ClienteController : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            //ENDPOINTS
            app.MapGet("v1/clientes", HandleGetAllAsync).Produces<PagedResponse<List<dynamic>?>>();
            app.MapGet("v1/cleintes/{id}", HandleGetByIdAsync).Produces<Response<dynamic>>();
            app.MapPost("v1/clientes", HandleCreateAsync).Produces<Response<dynamic?>>();
            app.MapPut("v1/clientes", HandleUpdateAsync).Produces<Response<dynamic?>>();
            app.MapDelete("v1/clientes/{id}", HandleDeleteAsync).Produces<Response<dynamic?>>();                                
        }

        private static async Task<IResult> HandleGetAllAsync(IClienteHandler handler, HttpRequest httpRequest, HttpContext httpContext)
        {
            var request = new GetAllRequest { QueryParams = Helper.NormalizeQueryParams(httpRequest.Query) };
            var response = await handler.GetAllAsync(request);
            return response.IsSuccess ? TypedResults.Ok(new
            {
                response.Data!.CurrentPage,
                response.Data.TotalPages,
                response.Data.PageSize,
                response.Data.TotalCount,
                data = response.Data.Data,
            }) : TypedResults.BadRequest(response);
        }
        private static async Task<IResult> HandleGetByIdAsync(IClienteHandler handler, HttpRequest httpRequest, HttpContext httpContext, string id)
        {
            var request = new GetByIdRequest { Id = id };
            var response = await handler.GetByIdAsync(request);

            return response.IsSuccess
                ? TypedResults.Ok(new
                {
                    response.Data
                })
                : TypedResults.BadRequest(response);
        }
private static async Task<IResult> HandleUpdateAsync(IClienteHandler handler, HttpContext httpContext, UpdateClienteRequest request)
        {
            var response = await handler.UpdateAsync(request);
            return response.IsSuccess ? TypedResults.Ok(new
            {
                message = response.Message,
                data = response.Data
            })
                : TypedResults.BadRequest(response);
        }
        private static async Task<IResult> HandleCreateAsync(IClienteHandler handler, HttpContext httpContext, CreateClienteRequest request)
        {
            var response = await handler.CreateAsync(request);
            return response.IsSuccess
                ? TypedResults.Created($"v1/clientes/{response.Data?.Id}", new
                {
                    message = response.Message,
                    data = response.Data
                })
                : TypedResults.BadRequest(response);
        }
private static async Task<IResult> HandleDeleteAsync(IClienteHandler handler, HttpContext httpContext, string id)
        {
            var request = new DeleteRequest
            {
                Id = id,
            };
            var response = await handler.DeleteAsync(request);
            return response.IsSuccess ? TypedResults.Ok(new
            {
                message = response.Message,
                data = response.Data
            })
                : TypedResults.BadRequest(response);
        }
    }
}