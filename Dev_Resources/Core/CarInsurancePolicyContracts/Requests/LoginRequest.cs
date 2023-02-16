using System;
using System.ComponentModel.DataAnnotations;

namespace CarInsurancePolicyContracts.Requests
{
    public class LoginRequest
    {
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Longitud inválida"),
            Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string UserName { get; set; }

        [StringLength(15, MinimumLength = 4, ErrorMessage = "Longitud inválida"),
            Required(AllowEmptyStrings = false, ErrorMessage = "El campo es requerido")]
        public string Password { get; set; }
    }
}

