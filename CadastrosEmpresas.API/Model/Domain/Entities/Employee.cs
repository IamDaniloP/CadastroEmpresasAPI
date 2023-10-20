using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public Guid Id { get; set; }
    public string NameEmployee { get; set; }
    public DateOnly BirthDate { get; set; }
    public string CPF { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
    public DateOnly HireDate { get; set; }

    [ForeignKey("CompaniesCNPJ")]
    public string CompaniesCNPJ { get; set; }
    public Companies Companies { get; set; }


    [ForeignKey("DepartmentId")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public List<EmployeeTask> EmployeeTasks { get; set; }

    public Employee() 
    { 
        Id = Guid.NewGuid();
        EmployeeTasks = new List<EmployeeTask>();
    }

    public void MapFromDto(EmployeeDto employeeDto)
    {
        NameEmployee = employeeDto.NameEmployee;
        BirthDate = employeeDto.BirthDate;
        CPF = employeeDto.CPF;
        PhoneNumber = employeeDto.PhoneNumber;
        Email = employeeDto.Email;
        RoleName = employeeDto.RoleName;
        HireDate = employeeDto.HireDate;
        CompaniesCNPJ = employeeDto.CompaniesCNPJ;
        DepartmentId = employeeDto.DepartmentId;
    }
}