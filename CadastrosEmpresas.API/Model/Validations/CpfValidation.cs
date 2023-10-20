using System.ComponentModel.DataAnnotations;

namespace CadastrosEmpresas.API.Model.Validations
{
    public class CpfValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string cpf = value.ToString();

                cpf = cpf.Replace(".", "");
                cpf = cpf.Replace("-", "");

                if (string.IsNullOrEmpty(cpf))
                {
                    return new ValidationResult("Invalid CPF.");
                }

                if (cpf.Length != 11)
                {
                    return new ValidationResult("Invalid CPF.");
                }

                //criar validação depois

                return ValidationResult.Success;
            }

            return new ValidationResult("CPF empty.");
        }
    }
}
