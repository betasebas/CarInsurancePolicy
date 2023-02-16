using System;
using CarInsurancePolicyContracts.Requests;
using CarInsurancePolicyDomain.Exceptions;
using CarInsurancePolicyService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurancePolicyApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly ITokenJwt _tokenJwt;

        public LoginController(ITokenJwt tokenJwt)
        {
            _tokenJwt = tokenJwt;
        }

        [HttpPost]
        [Route("LoginUser")]
        public ActionResult LoginUser(LoginRequest loginRequest)
        {
            try
            {
                var response = _tokenJwt.GetJwtAsync(loginRequest);
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

