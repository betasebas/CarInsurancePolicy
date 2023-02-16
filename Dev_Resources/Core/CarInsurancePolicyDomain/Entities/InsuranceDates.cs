using System;
namespace CarInsurancePolicyDomain.Entities
{
    public class InsuranceDates : BaseEntity
    {
        public string PolicyNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}

