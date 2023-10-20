using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CadastrosEmpresas.API.Model.Validations;

namespace CadastrosEmpresas.API.Model.Dtos
{
    public class EmployeeDto
    {
        [Required]
        [JsonPropertyName("nomeEmployee")]
        public string NameEmployee { get; set; }

        [Required]
        [JsonPropertyName("birthDate")]
        public DateOnly BirthDate { get; set; }

        [CpfValidation]
        [JsonPropertyName("cpf")]
        public string CPF { get; set; }

        [Required]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "invalid email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("role")]
        public string RoleName { get; set; }

        [Required]
        [JsonPropertyName("hireDate")]
        public DateOnly HireDate { get; set; }

        [Required]
        [JsonPropertyName("companiesCNPJ")]
        public string CompaniesCNPJ { get; set; }

        [Required]
        [JsonPropertyName("departmentId")]
        public int DepartmentId { get; set; }

        public EmployeeDto() { }
        public EmployeeDto(string nameEmployee, string birthDate, string cpf, string phoneNumber, string email, string roleName, string hireDate, string companies, int department)
        {
            NameEmployee = nameEmployee;
            BirthDate = DateOnly.Parse(birthDate);
            CPF = cpf;
            PhoneNumber = phoneNumber;
            Email = email;
            RoleName = roleName;
            HireDate = DateOnly.Parse(hireDate);
            CompaniesCNPJ = companies;
            DepartmentId = department;
        }
    }
}
