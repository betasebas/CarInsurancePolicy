using System;
using AutoMapper;
using CarInsurancePolicyContracts.Requests;
using CarInsurancePolicyContracts.Responses;
using CarInsurancePolicyDomain.Entities;
using CarInsurancePolicyDomain.Exceptions;
using CarInsurancePolicyDomain.Helpers;
using CarInsurancePolicyPersistence.Repositories;
using Microsoft.Extensions.Logging;

namespace CarInsurancePolicyService.Services
{
    public class CarInsuranceServices : ICarInsuranceServices
    {
        private readonly ICarInsurancePolicyRepository _carInsurancePolicyRepository;
        private readonly IInsuranceDatesService _insuranceDatesService;
        private readonly ILogger<CarInsuranceServices> _logger;

        public CarInsuranceServices(ICarInsurancePolicyRepository carInsurancePolicyRepository, IInsuranceDatesService insuranceDatesService,
             ILogger<CarInsuranceServices> logger)
        {
            _carInsurancePolicyRepository = carInsurancePolicyRepository;
            _insuranceDatesService = insuranceDatesService;
            _logger = logger;
        }

        public async Task<ResponseGeneric<bool>> SaveCarInsurance(CarInsurancePolicyRequest carInsurancePolicyRequest)
        {
            _logger.LogInformation("Inicio guardado de pólizas");
            var responsePolicies = _insuranceDatesService.GetAllInsuranceDates();
            ValidateError(responsePolicies);
            ValidateValidityPolice(carInsurancePolicyRequest.PolicyNumber, responsePolicies.Detail);
            CarInsurancePolicy carInsurancePolicy = GetModelSave(carInsurancePolicyRequest);
            string parameters = ParametersHelper.GetParametersProcedure(carInsurancePolicy);
            _logger.LogInformation($"Paramtros generados para Sp {parameters}");
            var responseInsert = await _carInsurancePolicyRepository.ExecuteProcedureInsertAsync("Sp_Insert_CarInsurancePolicy", parameters);
            ValidateResponseInsert(responseInsert);
            _logger.LogInformation("Finaliza el guardado de la póliza");
            return new ResponseGeneric<bool> { Code = 200, Message = "Operacion Exitosa",  Detail = true };
        }

        public async Task<ResponseGeneric<CarInsurancePolicy>> GetPolicyByFilter(string filter)
        {
            _logger.LogInformation("Inicio consulta de póliza");
            var responseGet = await _carInsurancePolicyRepository.GetByFilter(filter);
            ValidateResponseGet(responseGet);
            responseGet.Id = Guid.Empty;
            _logger.LogInformation("Finaliza la consulta de la póliza");
            return new ResponseGeneric<CarInsurancePolicy> { Code = 200, Message = "Operacion Exitosa", Detail = responseGet };
        }

        #region "Save Policy"

        private CarInsurancePolicy GetModelSave(CarInsurancePolicyRequest carInsurancePolicyRequest)
        {
            return new CarInsurancePolicy
            {
                PolicyName = carInsurancePolicyRequest.PolicyName,
                PolicyNumber = carInsurancePolicyRequest.PolicyNumber,
                ClientBirthdate = Convert.ToDateTime(carInsurancePolicyRequest.ClientBirthdate),
                ClientIdentification = carInsurancePolicyRequest.ClientIdentification,
                ClientName = carInsurancePolicyRequest.ClientName,
                CoveragePolicy = carInsurancePolicyRequest.CoveragePolicy,
                MaxValue = Convert.ToDecimal(carInsurancePolicyRequest.MaxValue),
                City = carInsurancePolicyRequest.City,
                Direction = carInsurancePolicyRequest.Direction,
                LicensePlate = carInsurancePolicyRequest.LicensePlate,
                ModelCar = Convert.ToInt32(carInsurancePolicyRequest.ModelCar),
                HaveInspection = Convert.ToBoolean(carInsurancePolicyRequest.HaveInspection)
            };
        }

        private void ValidateResponseInsert(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogError("Se presento un error insertando la póliza");
                throw new BadRequestException($"Se presento un error insertando la póliza");
            }
        }

        private void ValidateValidityPolice(string policyNumber, List<InsuranceDates> detail)
        {
            var policy = detail.FirstOrDefault(x => x.PolicyNumber.Equals(policyNumber));
            if (policy == null)
            {
                _logger.LogError($"No se han configurado póliza # {policy}");
                throw new BadRequestException($"No se han configurado póliza # {policy}");
            }

            if(policy.EndDate.Date <= DateTime.Now.Date)
            {
                _logger.LogError($"La póliza # {policy} no se encuentra vigente");
                throw new BadRequestException($"La póliza # {policy} no se encuentra vigente");
            }

        }

        private void ValidateError(ResponseGeneric<List<InsuranceDates>> responsePolicies)
        {
            if (responsePolicies.Code != 200 || responsePolicies.Detail.Count < 1)
            {
                _logger.LogError("No se han configurado pólizas");
                throw new BadRequestException("No se han configurado pólizas");
            }
        }

        #endregion

        #region "Get Policy"

        private void ValidateResponseGet(CarInsurancePolicy responseGet)
        {
            if(responseGet == null || responseGet.Id == Guid.Empty)
            {
                _logger.LogError("No se encontro póliza asociada");
                throw new BadRequestException($"No se encontro póliza asociada");
            }
        }

        #endregion
    }
}

