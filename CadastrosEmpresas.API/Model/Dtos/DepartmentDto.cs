using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastrosEmpresas.API.Model.Dtos
{
    public class DepartmentDto
    {
        [Required]
        [JsonPropertyName("departmentName")]
        public string DepartmentName { get; set; }

        [Required]
        [JsonPropertyName("headOfTheDepartment")]
        public string HeadOfTheDepartment { get; set; }

        [Required]
        [JsonPropertyName("departmentDescription")]
        public string DepartmentDescription { get; set; }

        [Required]
        [JsonPropertyName("companiesCnpj")]
        public string CompaniesCNPJ { get; set; }

        public DepartmentDto() { }

        public DepartmentDto(string departmentName, string headOfTheDepartment, string departmentDescription, string companies)
        {
            DepartmentName = departmentName;
            HeadOfTheDepartment = headOfTheDepartment;
            DepartmentDescription = departmentDescription;
            CompaniesCNPJ = companies;
        }
    }
}
