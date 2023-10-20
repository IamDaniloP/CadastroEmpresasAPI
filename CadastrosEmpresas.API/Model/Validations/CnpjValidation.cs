using System.ComponentModel.DataAnnotations;

namespace CadastrosEmpresas.API.Model.Validations
{
    public class CnpjValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string cnpj = value.ToString();

                cnpj = cnpj.Replace(".", "");
                cnpj = cnpj.Replace("/", "");
                cnpj = cnpj.Replace("-", "");

                if (string.IsNullOrEmpty(cnpj))
                {
                    return new ValidationResult("Invalid CNPJ.");
                }

                if (cnpj.Length != 14)
                {
                    return new ValidationResult("Invalid CNPJ.");
                }

                //criar validação depois

                return ValidationResult.Success;
            }

            return new ValidationResult("CNPJ empty.");
        }
    }
}
