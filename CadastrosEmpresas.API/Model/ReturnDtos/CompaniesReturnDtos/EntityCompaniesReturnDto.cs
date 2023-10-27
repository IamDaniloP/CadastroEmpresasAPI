using CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;

namespace CadastrosEmpresas.API.Model.ReturnDtos.CompaniesReturnDtos
{
    public class EntityCompaniesReturnDto
    {
        public string CompaniesName { get; set; }
        public DateOnly CreationDate { get; set; }
        public string CEO { get; set; }
        public string CNPJ { get; set; }
        public string Niche { get; set; }

        public List<EmployeeReturnDto> Employees { get; set; }

        public List<DepartmentReturnDto> Departments { get; set; }

        public EntityCompaniesReturnDto() { }

        public void MapFromEntityReturnDto(Companies companies)
        {
            CompaniesName = companies.CompaniesName;
            CreationDate = companies.CreationDate;
            CEO = companies.CEO;
            CNPJ = companies.CNPJ;
            Niche = companies.Niche;
        }
    }
}
