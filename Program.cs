using apiExemplo.src.Common;
using apiExemplo.src.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.AddAuthenticationJwt();
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddAuthorization();
builder.Services.AddAntiforgery();
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(access => access.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAntiforgery();
app.UseCors("AllowAnyCorsPolicy");
app.MapEndpoints();
app.UseAuthentication();
app.UseAuthorization();
app.UseSmartMiddlewares(builder);
app.UseResponseCaching();

app.Run();
