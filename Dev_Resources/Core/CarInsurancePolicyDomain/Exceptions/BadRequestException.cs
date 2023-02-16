using System;
namespace CarInsurancePolicyDomain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message): base(message)
        {
        }

        public BadRequestException(string message, Exception innerException): base(message, innerException)
        {
        }

        protected BadRequestException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context): base(info, context)
        {
        }
    }
}

