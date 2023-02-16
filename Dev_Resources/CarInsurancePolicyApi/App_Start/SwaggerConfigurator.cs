using System;
using Microsoft.OpenApi.Models;

namespace CarInsurancePolicyApi.App_Start
{
    public static class SwaggerConfigurator
    {
        public static IApplicationBuilder AddUseSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Car Insurance Policy");

            });
            return app;
        }

        public static IServiceCollection AddSwaggerComponent(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Car Insurance Policy",
                    Description = "Api to save the policies",
                    Contact = new OpenApiContact() { Name = "policies", Email = "mail@mail.com"}
                });
            });

            return services;
        }
    }
}

