using System;
using CarInsurancePolicyContracts.Requests;
using CarInsurancePolicyContracts.Responses;
using CarInsurancePolicyDomain.Entities;

namespace CarInsurancePolicyService.Services
{
    public interface ICarInsuranceServices
    {
        Task<ResponseGeneric<bool>> SaveCarInsurance(CarInsurancePolicyRequest carInsurancePolicyRequest);

        Task<ResponseGeneric<CarInsurancePolicy>> GetPolicyByFilter(string filter);
    }
}

