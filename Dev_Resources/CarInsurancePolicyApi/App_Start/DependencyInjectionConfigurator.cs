using System;
using CarInsurancePolicyApi.Middleware;
using CarInsurancePolicyPersistence.Repositories;
using CarInsurancePolicyService.Services;

namespace CarInsurancePolicyApi.App_Start
{
    public static class DependencyInjectionConfigurator
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICarInsurancePolicyRepository, CarInsurancePolicyRepository>();
            services.AddScoped<IInsuranceDatesRepository, InsuranceDatesRepository>();
            services.AddScoped<ITokenJwt, TokenJwt>();
            services.AddScoped<IInsuranceDatesService, InsuranceDatesService>();
            services.AddScoped<ICarInsuranceServices, CarInsuranceServices>();

            services.AddTransient<ExceptionMiddleware>();
        }
    }
}

