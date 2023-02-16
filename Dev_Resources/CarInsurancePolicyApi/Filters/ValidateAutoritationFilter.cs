using System;
using CarInsurancePolicyDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarInsurancePolicyApi.Filters
{
    public class ValidateAutoritationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("Authoritation"))
            {
                var claims = context.HttpContext.User.Claims.ToList();
                var session = from claim in claims where claim.Type == "UserName" select claim;
                if (session.Any())
                {
                    await next();
                }

                context.Result = new UnauthorizedResult();
            }

            await next();
        }
    }
}

