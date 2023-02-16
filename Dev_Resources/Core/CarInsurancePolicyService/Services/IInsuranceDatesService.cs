using System;
using CarInsurancePolicyContracts.Responses;
using CarInsurancePolicyDomain.Entities;

namespace CarInsurancePolicyService.Services
{
    public interface IInsuranceDatesService
    {
        ResponseGeneric<List<InsuranceDates>> GetAllInsuranceDates();
    }
}

