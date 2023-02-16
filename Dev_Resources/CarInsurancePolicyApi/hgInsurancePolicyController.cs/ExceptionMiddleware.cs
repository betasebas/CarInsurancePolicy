using System;
using System.Net;
using CarInsurancePolicyDomain.Exceptions;
using Newtonsoft.Json;

namespace CarInsurancePolicyApi.Middleware
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = ex switch
            {
                BadRequestException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = new
            {
                Code = httpContext.Response.StatusCode,
                Message = ex.Message,
                Detail = ex.Source
            };

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}

