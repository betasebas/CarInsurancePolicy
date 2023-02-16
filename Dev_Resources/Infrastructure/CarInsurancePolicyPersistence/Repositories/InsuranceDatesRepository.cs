using System;
using CarInsurancePolicyDomain.Entities;

namespace CarInsurancePolicyPersistence.Repositories
{
    public class InsuranceDatesRepository : IInsuranceDatesRepository
    {
        public List<InsuranceDates> GetAll()
        {
            return new List<InsuranceDates>
            {
                new InsuranceDates{ PolicyNumber = "POL0001", StartDate = new DateTime(2023,1,1), EndDate = new DateTime(2025,1,1)},
                new InsuranceDates{ PolicyNumber = "POL0002", StartDate = new DateTime(2022,1,1), EndDate = new DateTime(2026,1,1)},
                new InsuranceDates{ PolicyNumber = "POL0003", StartDate = new DateTime(2023,2,1), EndDate = new DateTime(2027,1,1)},
                new InsuranceDates{ PolicyNumber = "POL0004", StartDate = new DateTime(2023,1,1), EndDate = new DateTime(2024,3,4)},
                new InsuranceDates{ PolicyNumber = "POL0005", StartDate = new DateTime(2023,1,2), EndDate = new DateTime(2025,3,4)},
                new InsuranceDates{ PolicyNumber = "POL0006", StartDate = new DateTime(2022,6,7), EndDate = new DateTime(2024,5,6)},
                new InsuranceDates{ PolicyNumber = "POL0007", StartDate = new DateTime(2020,1,1), EndDate = new DateTime(2023,1,1)},
                new InsuranceDates{ PolicyNumber = "POL0008", StartDate = new DateTime(2023,1,1), EndDate = new DateTime(2025,5,6)},
                new InsuranceDates{ PolicyNumber = "POL0009", StartDate = new DateTime(2023,3,2), EndDate = new DateTime(2025,4,5)},
                new InsuranceDates{ PolicyNumber = "POL0010", StartDate = new DateTime(2022,1,5), EndDate = new DateTime(2028,3,3)}
            };
        }
    }
}

