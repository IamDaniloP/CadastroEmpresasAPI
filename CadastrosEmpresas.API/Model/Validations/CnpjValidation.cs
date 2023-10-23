using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CadastrosEmpresas.API.Model.Validations
{
    public class CnpjValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {

            string cnpj = value.ToString();

            cnpj = cnpj.Replace(".", "");
            cnpj = cnpj.Replace("-", "");
            cnpj = cnpj.Replace("/", "");

            if (string.IsNullOrEmpty(cnpj) || cnpj.Length != 14 || isSequence(cnpj)) return new ValidationResult("Empty or Invalid CNPJ.");

            var verifiedCnpj = cnpjNumberCalculation(cnpj);
            if (verifiedCnpj == cnpj) return ValidationResult.Success;

            return new ValidationResult("Invalid CNPJ");
        }

        private Boolean isSequence(string cnpj)
        {
            if (repeatString(cnpj[0], 14) == cnpj) return true;
            return false;
        }

        private string repeatString(char char0Cnpj, int repeat)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < repeat; i++)
            {
                stringBuilder.Append(char0Cnpj);
            }

            return stringBuilder.ToString();
        }

        private string cnpjNumberCalculation(string cnpj)
        {
            string cnpjWithoutDigits = cnpj.Substring(0, cnpj.Length - 2);

            string firstDigit = firstDigitCalculation(cnpjWithoutDigits);
            string secondDigit = secondDigitCalculation(cnpjWithoutDigits + firstDigit);

            return $"{cnpjWithoutDigits}{firstDigit}{secondDigit}";
        }

        private string firstDigitCalculation(string cnpjWithoutDigits)
        {
            int total = 0;
            int[] multiples = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < cnpjWithoutDigits.Length; i++)
            {
                total += (cnpjWithoutDigits[i] - '0') * multiples[i];
            }

            int digit = total % 11;
            if (digit == 0 || digit == 1) return "0";
            return (11 - digit).ToString();
        }

        private string secondDigitCalculation(string cnpjWithoutLastDigit)
        {
            int total = 0;
            int[] multiples = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < cnpjWithoutLastDigit.Length; i++)
            {
                total += (cnpjWithoutLastDigit[i] - '0') * multiples[i];
            }

            int digit = total % 11;
            if (digit == 0 || digit == 1) return "0";
            return (11 - digit).ToString();
        }
    }
}
