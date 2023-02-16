using System;
using AutoMapper;
using CarInsurancePolicyContracts.Responses;
using CarInsurancePolicyDomain.Entities;
using CarInsurancePolicyPersistence.Repositories;
using Microsoft.Extensions.Logging;

namespace CarInsurancePolicyService.Services
{
    public class InsuranceDatesService : IInsuranceDatesService
    {
        private readonly IInsuranceDatesRepository _insuranceDatesRepository;
        private readonly ILogger<InsuranceDatesService> _logger;

        public InsuranceDatesService(IInsuranceDatesRepository insuranceDatesRepository, ILogger<InsuranceDatesService> logger)
        {
            _insuranceDatesRepository = insuranceDatesRepository;
            _logger = logger;
        }

        public ResponseGeneric<List<InsuranceDates>> GetAllInsuranceDates()
        {
            _logger.LogInformation("Inicio Consulta de polizas");
            var policies = _insuranceDatesRepository.GetAll();
            _logger.LogInformation("Fin Consulta de polizas");
            return new ResponseGeneric<List<InsuranceDates>>
            {
                Code = 200,
                Message = "Consulta exitosa",
                Detail = policies
            };

        }
    }
}

