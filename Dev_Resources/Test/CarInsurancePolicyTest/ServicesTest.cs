using System;
using CarInsurancePolicyPersistence.Repositories;
using CarInsurancePolicyDomain.Entities;
using Moq;
using CarInsurancePolicyService.Services;
using CarInsurancePolicyContracts.Responses;
using Microsoft.Extensions.Logging;
using Castle.Core.Logging;
using CarInsurancePolicyContracts.Requests;
using CarInsurancePolicyDomain.Exceptions;

namespace CarInsurancePolicyTest
{
    public class ServicesTest
    {
        private readonly Mock<ICarInsurancePolicyRepository> _CarInsurancePolicyRepositoryMock;
        private readonly Mock<IInsuranceDatesService> _insurenceDatesServiceMock;
        private readonly Mock<ILogger<CarInsuranceServices>> _logger;
        private List<InsuranceDates> policiesDates = new List<InsuranceDates>
            {
                new InsuranceDates{ PolicyNumber = "POL0001", StartDate = new DateTime(2023,1,1), EndDate = new DateTime(2025,1,1)},
                new InsuranceDates{ PolicyNumber = "POL0002", StartDate = new DateTime(2022,1,1), EndDate = new DateTime(2026,1,1)},
                new InsuranceDates { PolicyNumber = "POL0003", StartDate = new DateTime(2023, 2, 1), EndDate = new DateTime(2027, 1, 1) },
                new InsuranceDates { PolicyNumber = "POL0004", StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2024, 3, 4) },
                new InsuranceDates { PolicyNumber = "POL0005", StartDate = new DateTime(2023, 1, 2), EndDate = new DateTime(2025, 3, 4) },
                new InsuranceDates { PolicyNumber = "POL0006", StartDate = new DateTime(2022, 6, 7), EndDate = new DateTime(2024, 5, 6) },
                new InsuranceDates { PolicyNumber = "POL0007", StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2023, 1, 1) },
                new InsuranceDates { PolicyNumber = "POL0008", StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2025, 5, 6) },
                new InsuranceDates { PolicyNumber = "POL0009", StartDate = new DateTime(2023, 3, 2), EndDate = new DateTime(2025, 4, 5) },
                new InsuranceDates { PolicyNumber = "POL0010", StartDate = new DateTime(2022, 1, 5), EndDate = new DateTime(2028, 3, 3) }
            };
        private CarInsurancePolicyRequest carInsurancePolicyRequest = new CarInsurancePolicyRequest
        {
            PolicyNumber = "POL0002",
            ClientName = "JUAN PABLO GOMEZ",
            ClientIdentification = "6666666666",
            ClientBirthdate = new DateTime(2003, 2, 3),
            CoveragePolicy = "Cubre total, danos, choques",
            MaxValue = 90000000,
            PolicyName = "Cubre todo",
            City = "Medellin",
            Direction = "Carrera 88 # 90 87",
            LicensePlate = "YUT678",
            ModelCar = 2019,
            HaveInspection = false
        };


        public ServicesTest()
        {
            _CarInsurancePolicyRepositoryMock = new Mock<ICarInsurancePolicyRepository>();
            _insurenceDatesServiceMock = new Mock<IInsuranceDatesService>();
            _logger = new Mock<ILogger<CarInsuranceServices>>();



            _CarInsurancePolicyRepositoryMock.Setup(
                x => x.GetByFilter(It.IsAny<string>()))
                .ReturnsAsync(new CarInsurancePolicy { Id = Guid.NewGuid() });
        }

        [Fact]
        public async Task Test_SaveInsurance_Ok()
        {
            _insurenceDatesServiceMock.Setup(x => x.GetAllInsuranceDates())
                .Returns(new ResponseGeneric<List<InsuranceDates>> { Code = 200, Detail = policiesDates });

            _CarInsurancePolicyRepositoryMock.Setup(x =>
                x.ExecuteProcedureInsertAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(Guid.NewGuid());

            var carInsuranceServices = new CarInsuranceServices(_CarInsurancePolicyRepositoryMock.Object, _insurenceDatesServiceMock.Object, _logger.Object);
            var response = await carInsuranceServices.SaveCarInsurance(carInsurancePolicyRequest);
            Assert.Equal(200, response.Code);
        }


        [Fact]
        public async Task Test_GetInsurance_Ok()
        {
            _CarInsurancePolicyRepositoryMock.Setup(
                x => x.GetByFilter(It.IsAny<string>()))
                .ReturnsAsync(new CarInsurancePolicy { Id = Guid.NewGuid() });

            var carInsuranceServices = new CarInsuranceServices(_CarInsurancePolicyRepositoryMock.Object, _insurenceDatesServiceMock.Object, _logger.Object);
            var response = await carInsuranceServices.GetPolicyByFilter("");
            Assert.Equal(200, response.Code);
        }

        [Fact]
        public async Task Test_SaveInsurance_Error()
        {
            _insurenceDatesServiceMock.Setup(x => x.GetAllInsuranceDates())
               .Returns(new ResponseGeneric<List<InsuranceDates>> { Code = 200, Detail = policiesDates });

            _CarInsurancePolicyRepositoryMock.Setup(x =>
                x.ExecuteProcedureInsertAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(Guid.Empty);

            var carInsuranceServices = new CarInsuranceServices(_CarInsurancePolicyRepositoryMock.Object, _insurenceDatesServiceMock.Object, _logger.Object);
            await Assert.ThrowsAsync<BadRequestException>(async () => await carInsuranceServices.SaveCarInsurance(carInsurancePolicyRequest));
        }

        [Fact]
        public async Task Test_GetInsurance_Error()
        {
            _CarInsurancePolicyRepositoryMock.Setup(
                x => x.GetByFilter(It.IsAny<string>()))
                .ReturnsAsync(new CarInsurancePolicy { Id = Guid.Empty});

            var carInsuranceServices = new CarInsuranceServices(_CarInsurancePolicyRepositoryMock.Object, _insurenceDatesServiceMock.Object, _logger.Object);
            await Assert.ThrowsAsync<BadRequestException>(async () => await carInsuranceServices.GetPolicyByFilter(""));
        }

    }
}

