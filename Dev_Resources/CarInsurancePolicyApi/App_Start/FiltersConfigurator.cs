using System;
using CarInsurancePolicyApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurancePolicyApi.App_Start
{
    public static class FiltersConfigurator
    {
        public static IServiceCollection AddFilterController(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opts => opts.SuppressModelStateInvalidFilter = true);
            services.AddControllers(options =>
            {
                options.Filters.Add(new ValidateAutoritationFilter());
                options.Filters.Add(new ValidateModelFilter());
   
            });

            return services;
        }
    }
}

