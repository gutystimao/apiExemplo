using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiExemplo.src.Common
{
    public static class AppExtension
    {
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public static void UseSmartMiddlewares(this WebApplication app, WebApplicationBuilder builder)
        {
            string urlGtw = builder.Configuration["Gtw:uri"] ?? "";
            app.Use(async (context, next) =>
            {
                await next(context);
            });
        }
    }
}