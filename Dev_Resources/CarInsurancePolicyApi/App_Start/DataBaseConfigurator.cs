using System;
using CarInsurancePolicyPersistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarInsurancePolicyApi.App_Start
{
    public static class DataBaseConfigurator
    {
        public static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CarInsurancePolicyContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}

