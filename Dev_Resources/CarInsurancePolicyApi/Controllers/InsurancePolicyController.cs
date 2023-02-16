using System;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using CarInsurancePolicyService.Services;
using CarInsurancePolicyContracts.Requests;
using CarInsurancePolicyDomain.Exceptions;

namespace CarInsurancePolicyPresentation.V1.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InsurancePolicyController : ControllerBase
    {
        private readonly ICarInsuranceServices _carInsuranceServices;
        

        public InsurancePolicyController(ICarInsuranceServices carInsuranceServices)
        {
            _carInsuranceServices = carInsuranceServices;
        }

        [HttpPost]
        [Route("SaveCarInsurancePolicy")]
        public async Task<IActionResult> SaveCarInsurancePolicy(CarInsurancePolicyRequest carInsurancePolicyRequest)
        {
            try
            {
                var response = await _carInsuranceServices.SaveCarInsurance(carInsurancePolicyRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if(ex is BadRequestException)
                {
                    throw;
                }

                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("GetCarInsurancePolicy/{filter]")]
        public async Task<IActionResult> GetCarInsurancePolicy(string filter)
        {
            try
            {
                var response = await _carInsuranceServices.GetPolicyByFilter(filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex is BadRequestException)
                {
                    throw;
                }

                return BadRequest(ex.Message);
            }

        }
    }
}

