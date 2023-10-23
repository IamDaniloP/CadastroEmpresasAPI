using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.CompaniesReturnDtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IcompaniesService
    {
        public void createCompanies(CompaniesDto companiesDto);
        public void updateCompanies(string cnpj, CompaniesDto companiesDto);
        public void deleteCompanies(string cpnj);
        public EntityCompaniesReturnDto getCompanies(string cnpj);
        public List<EntityCompaniesReturnDto> getAllCompanies();
    }
}
