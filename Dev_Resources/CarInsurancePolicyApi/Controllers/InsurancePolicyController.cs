using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CarInsurancePolicyContracts.Requests;
using CarInsurancePolicyDomain.Exceptions;
using CarInsurancePolicyService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarInsurancePolicyApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
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
                if (ex is BadRequestException)
                {
                    throw;
                }

                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GetCarInsurancePolicy/{filter}")]
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