using System;
namespace CarInsurancePolicyContracts.Responses
{
    public class ResponseGeneric<T>
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public T Detail { get; set; }
    }
}

