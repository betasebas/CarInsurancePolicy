using System;
using System.Reflection;
using CarInsurancePolicyDomain.Entities;

namespace CarInsurancePolicyDomain.Helpers
{
    public static class ParametersHelper
    {
        public static string GetParametersProcedure(CarInsurancePolicy carInsurancePolicy)
        {
            string parameters = string.Empty;
            parameters += $"@PolicyNumber = '{carInsurancePolicy.PolicyNumber}'";
            parameters += $", @ClientName = '{carInsurancePolicy.ClientName}'";
            parameters += $", @ClientIdentification = '{carInsurancePolicy.ClientIdentification}'";
            parameters += $", @ClientBirthdate = '{carInsurancePolicy.ClientBirthdate.Date.ToString("yyyy-MM-dd")}'";
            parameters += $", @CoveragePolicy = '{carInsurancePolicy.CoveragePolicy}'";
            parameters += $", @MaxValue = {carInsurancePolicy.MaxValue}";
            parameters += $", @PolicyName = '{carInsurancePolicy.PolicyName}'";
            parameters += $", @City = '{carInsurancePolicy.City}'";
            parameters += $", @Direction = '{carInsurancePolicy.Direction}'";
            parameters += $", @LicensePlate = '{carInsurancePolicy.LicensePlate}'";
            parameters += $", @ModelCar = {carInsurancePolicy.ModelCar}";
            parameters += $", @HaveInspection = '{carInsurancePolicy.HaveInspection}'";
            parameters += $", @DateCreation = '{carInsurancePolicy.DateCreation.Date.ToString("yyyy-MM-dd")}'";
            return parameters;
        }
    }
}

