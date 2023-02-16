using System;
using System.ComponentModel.DataAnnotations;

namespace CarInsurancePolicyContracts.Requests
{
    public class CarInsurancePolicyRequest
    {
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Longitud inválida"),
            Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string PolicyNumber { get; set; }

        [StringLength(200, ErrorMessage = "Longitud inválida"),
          Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string ClientName { get; set; }


        [StringLength(30, MinimumLength = 10, ErrorMessage = "Longitud inválida"),
          Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string ClientIdentification { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public DateTime? ClientBirthdate { get; set; }

        [StringLength(600, ErrorMessage = "Longitud inválida"),
          Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string CoveragePolicy { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public decimal? MaxValue { get; set; }

        [StringLength(50, ErrorMessage = "Longitud inválida"),
          Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string PolicyName { get; set; }

        [StringLength(100,  ErrorMessage = "Longitud inválida"),
          Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string City { get; set; }

        [StringLength(100, ErrorMessage = "Longitud inválida"),
          Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string Direction { get; set; }

        [StringLength(10, MinimumLength = 6, ErrorMessage = "Longitud inválida"),
          Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string LicensePlate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public int? ModelCar { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public bool? HaveInspection { get; set; }
    }
}


