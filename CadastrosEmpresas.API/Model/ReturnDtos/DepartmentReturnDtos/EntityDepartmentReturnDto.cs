using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.ReturnDtos.CompaniesReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;

namespace CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos
{
    public class EntityDepartmentReturnDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string HeadOfTheDepartment { get; set; }
        public string DepartmentDescription { get; set; }
        public CompaniesReturnDto Companies { get; set; }

        public List<EmployeeReturnDto> Employees { get; set;}
        public List<TaskReturnDto> Tasks { get; set; }

        public EntityDepartmentReturnDto () { }

        public void MapFromEntityReturnDto(Department department)
        {
            Id = department.Id;
            DepartmentName = department.DepartmentName;
            HeadOfTheDepartment = department.HeadOfTheDepartment;
            DepartmentDescription = department.DepartmentDescription;

            Companies = new CompaniesReturnDto ();
            Companies.MapFromReturnDto(department.Companies);
        }
    }
}
