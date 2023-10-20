using CadastrosEmpresas.API.Model.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastrosEmpresas.API.Model.Domain.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public string HeadOfTheDepartment { get; set; }
        public string DepartmentDescription { get; set; }

        [ForeignKey("CompaniesCNPJ")]
        public string CompaniesCNPJ { get; set; }
        public Companies Companies { get; set; }

        public List<Employee> Employees { get; set; }

        public List<Task> Tasks { get; set; }

        public Department()
        { 
            Id = new Random().Next(1, 1000);
            Employees = new List<Employee>();
            Tasks = new List<Task>();
        }

        public void MapFromDto(DepartmentDto departmentDto)
        {
            DepartmentName = departmentDto.DepartmentName;
            HeadOfTheDepartment = departmentDto.HeadOfTheDepartment;
            DepartmentDescription = departmentDto.DepartmentDescription;
            CompaniesCNPJ = departmentDto.CompaniesCNPJ;
        }
    }

}
