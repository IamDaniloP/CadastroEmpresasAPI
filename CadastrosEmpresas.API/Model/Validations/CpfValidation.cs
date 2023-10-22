using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CadastrosEmpresas.API.Model.Validations
{
    public class CpfValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            string cpf = value.ToString();

            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");

            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || isSequence(cpf)) return new ValidationResult("Empty or Invalid CPF.");

            var verifiedCpf = cpfNumberCalculation(cpf);
            if (verifiedCpf == cpf) return ValidationResult.Success;

            return new ValidationResult($"Invalid CPF");
        }

        private Boolean isSequence(string cpf)
        {
            if (repeatString(cpf[0], 11) == cpf) return true;
            return false;
        }

        private string repeatString(char char0Cpf, int repeat)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < repeat; i++)
            {
                stringBuilder.Append(char0Cpf);
            }

            return stringBuilder.ToString();
        }

        private string cpfNumberCalculation(string cpf)
        {
            string cpfWithoutDigits = cpf.Substring(0, cpf.Length - 2);

            string firstDigit = digitsCalculation(cpfWithoutDigits);
            string secondDigit = digitsCalculation(cpfWithoutDigits + firstDigit);

            return $"{cpfWithoutDigits}{firstDigit}{secondDigit}";
        }

        private string digitsCalculation(string cpfWithoutDigits)
        {
            int total = 0;
            int count = cpfWithoutDigits.Length + 1;

            foreach (char value in  cpfWithoutDigits)
            {
                total += (value - '0') * count;
                count--;
            }

            int digit = 11 - (total % 11);
            return digit > 9 ? "0" : digit.ToString();
        }
    }
}
