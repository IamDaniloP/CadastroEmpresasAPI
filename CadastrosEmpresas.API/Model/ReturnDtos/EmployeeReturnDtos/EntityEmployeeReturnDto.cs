using CadastrosEmpresas.API.Model.ReturnDtos.CompaniesReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;

namespace CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos
{
    public class EntityEmployeeReturnDto
    {
        public Guid Id { get; set; }
        public string NameEmployee { get; set; }
        public DateOnly BirthDate { get; set; }
        public string CPF { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public DateOnly HireDate { get; set; }
        public CompaniesReturnDto Companies { get; set; }
        public DepartmentReturnDto Department { get; set; }

        public List<TaskReturnDto> EmployeeTasks { get; set; }

        public void MapFromEntityReturnDto(Employee employee)
        {
            Id = employee.Id;
            NameEmployee = employee.NameEmployee;
            BirthDate = employee.BirthDate;
            CPF = employee.CPF;
            PhoneNumber = employee.PhoneNumber;
            Email = employee.Email;
            RoleName = employee.RoleName;
            HireDate = employee.HireDate;

            Companies = new CompaniesReturnDto();
            Companies.MapFromReturnDto(employee.Companies);

            Department = new DepartmentReturnDto();
            Department.MapFromReturnDto(employee.Department);
        }
    }
}
