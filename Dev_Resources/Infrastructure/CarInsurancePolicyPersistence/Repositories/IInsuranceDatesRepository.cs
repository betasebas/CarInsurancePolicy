using System;
using CarInsurancePolicyDomain.Entities;

namespace CarInsurancePolicyPersistence.Repositories
{
    public interface IInsuranceDatesRepository 
    {
        List<InsuranceDates> GetAll();
    }
}

