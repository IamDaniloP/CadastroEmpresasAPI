using CadastrosEmpresas.API.Model.Dtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IcompaniesService
    {
        public void createCompanies(CompaniesDto companiesDto);
        public void updateCompanies(string cnpj, CompaniesDto companiesDto);
        public void deleteCompanies(string cpnj);
        public Companies getCompanies(string cnpj);
        public List<Companies> getAllCompanies();
    }
}
