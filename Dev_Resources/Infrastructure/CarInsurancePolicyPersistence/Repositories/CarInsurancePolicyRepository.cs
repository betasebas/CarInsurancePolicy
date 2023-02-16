using System;
using CarInsurancePolicyDomain.Entities;
using CarInsurancePolicyPersistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace CarInsurancePolicyPersistence.Repositories
{
    public class CarInsurancePolicyRepository : ICarInsurancePolicyRepository
    {
        private readonly CarInsurancePolicyContext _carInsurancePolicyContext;

        public CarInsurancePolicyRepository(CarInsurancePolicyContext carInsurancePolicyContext)
        {
            _carInsurancePolicyContext = carInsurancePolicyContext;
        }

        public async Task<CarInsurancePolicy> GetByFilter(string parameter)
        {
  
            var response =  await _carInsurancePolicyContext.CarInsurancePolicy.FirstOrDefaultAsync(x =>
                    x.LicensePlate.Equals(parameter) || x.PolicyNumber.Equals(parameter));
            return response;
        }

        public async Task<Guid> ExecuteProcedureInsertAsync(string name, string parameterNames)
        {
            var id = new SqlParameter("@Id", System.Data.SqlDbType.UniqueIdentifier);
            id.Direction = System.Data.ParameterDirection.Output;
            var execute = $@"EXECUTE {name} {parameterNames}, @Id = {id} OUTPUT";
            await _carInsurancePolicyContext.Database.ExecuteSqlRawAsync($"{execute}", id);
            return (Guid)id.Value;
        }
    }
}

