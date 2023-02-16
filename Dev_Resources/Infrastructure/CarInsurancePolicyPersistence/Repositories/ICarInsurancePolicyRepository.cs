using System;
using CarInsurancePolicyDomain.Entities;
using Microsoft.Data.SqlClient;

namespace CarInsurancePolicyPersistence.Repositories
{
    public interface ICarInsurancePolicyRepository
    {
        Task<Guid> ExecuteProcedureInsertAsync(string name, string parameterNames);

        Task<CarInsurancePolicy> GetByFilter(string parameter);
    }
}
