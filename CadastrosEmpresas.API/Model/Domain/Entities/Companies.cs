using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using System.ComponentModel.DataAnnotations;

public class Companies
{
    public string CompaniesName { get; set; }
    public DateOnly CreationDate { get; set; }
    public string CEO { get; set; }

    [Key]
    public string CNPJ { get; set; }
    public string Niche { get; set; }

    public List<Employee> Employees { get; set; }

    public List<Department> Departments { get; set; }

    public Companies()
    {
        Employees = new List<Employee>();
        Departments = new List<Department>();
    }

    public void MapFromDto(CompaniesDto companiesDto)
    {
        CompaniesName = companiesDto.CompaniesName;
        CreationDate = companiesDto.CreationDate;
        CEO = companiesDto.CEO;
        CNPJ = companiesDto.CNPJ;
        Niche = companiesDto.Niche;
    }
}