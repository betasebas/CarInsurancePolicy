using System;
using Microsoft.EntityFrameworkCore;
using CarInsurancePolicyDomain.Entities;

namespace CarInsurancePolicyPersistence.Contexts
{
    public partial class CarInsurancePolicyContext : DbContext
    {
        public CarInsurancePolicyContext(DbContextOptions<CarInsurancePolicyContext> options) : base(options)
        {
        }

        public virtual DbSet<CarInsurancePolicy> CarInsurancePolicy { get; set; }

       
    }
}

