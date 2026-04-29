using System.Text;
using apiExemplo.src.Data;
using apiExemplo.src.Handlers;
using apiExemplo.src.IHandlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;

namespace apiExemplo.src.Common
{
    public static class BuildExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            AppDbContext.ConnectionString = builder.Configuration.GetSection("MongoDBSettings:ConnectionString").Value;
            AppDbContext.DatabaseName = builder.Configuration.GetSection("MongoDBSettings:DatabaseName").Value;
            AppDbContext.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("MongoDBSettings:IsSSL").Value);
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });

            builder.Services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<AppDbContext>();
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                options => options.AddPolicy(
                    "AllowAnyCorsPolicy",
                    policy => policy
                        .WithOrigins([
                            // Configuration.CFGBackend,
                            // Configuration.FrontendUrl
                        ])
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                ));
        }

        public static void AddAuthenticationJwt(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                string key = builder.Configuration["Jwt:Key"] ?? "";
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserHandler, UserHandler>();
            builder.Services.AddTransient<IClienteHandler, ClienteHandler>();
            builder.Services.AddScoped<IProductHandler, ProductHandler>();
        }
    }
}