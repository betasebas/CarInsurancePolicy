using System;
namespace CarInsurancePolicyDomain.Entities
{
    public class CarInsurancePolicy : BaseEntity
    {
        public Guid Id { get; set; } = Guid.Empty;

        public string PolicyNumber { get; set; }

        public string ClientName { get; set; }

        public string ClientIdentification { get; set; }

        public DateTime ClientBirthdate { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;

        public string CoveragePolicy { get; set; }

        public decimal MaxValue { get; set; }

        public string PolicyName { get; set; }

        public string City { get; set; }

        public string Direction { get; set; }

        public string LicensePlate { get; set; }

        public int ModelCar { get; set; }

        public bool HaveInspection { get; set; }
    }
}

