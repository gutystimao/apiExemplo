using apiExemplo.src.Common;

namespace apiExemplo.src.Controllers
{
    public static class Endpoint
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var endpoints = app.MapGroup("");

            endpoints.MapGroup("api/v1/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("api/").WithTags("Usuarios").MapEndpoint<UserController>();
            endpoints.MapGroup("api/").WithTags("Clientes").MapEndpoint<ClienteController>();
            endpoints.MapGroup("api/").WithTags("Products").MapEndpoint<ProductController>();
        }
        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) 
        where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}