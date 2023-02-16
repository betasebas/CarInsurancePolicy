using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurancePolicyApi.Filters
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
                
            }
        }

    }

    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState) : base(new ValidateResulModel(modelState))
        {
            StatusCode = (int)HttpStatusCode.UnprocessableEntity;
        }
    }

    public class ValidateResulModel
    {
        private ModelStateDictionary modelState;

        public int Code { get; set; }

        public string Message { get; set; }

        public List<ValidateError> Detail { get; set; }

        public ValidateResulModel(ModelStateDictionary modelState)
        {
            Code = (int)HttpStatusCode.UnprocessableEntity;
            Message = "Model Invalid";
            Detail = modelState.Keys.
                        SelectMany(key => modelState[key].Errors.Select(x => new ValidateError(key, x.ErrorMessage)))
                        .ToList();
        }
    }

    public class ValidateError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AttributeError { get; set; }

        public string MessageError { get; set; }

        public ValidateError(string attributeError, string messageError)
        {
            AttributeError = attributeError;
            MessageError = messageError;
        }
    }
}

