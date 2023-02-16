using System;
using CarInsurancePolicyContracts.Requests;
using CarInsurancePolicyContracts.Responses;

namespace CarInsurancePolicyService.Services
{
    public interface ITokenJwt
    {
        ResponseGeneric<string> GetJwtAsync(LoginRequest loginRequest);
    }
}

