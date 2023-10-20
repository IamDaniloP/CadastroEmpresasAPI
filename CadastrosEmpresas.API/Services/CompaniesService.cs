using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Services.Interfaces;

namespace CadastrosEmpresas.API.Services
{
    public class CompaniesService : IcompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CompaniesService(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public void createCompanies(CompaniesDto companiesDto)
        {
            string formatCnpj = companiesDto.CNPJ;
            formatCnpj = formatCnpj.Replace(".", "");
            formatCnpj = formatCnpj.Replace("/", "");
            formatCnpj = formatCnpj.Replace("-", "");

            if (_companiesRepository.getCompanies(formatCnpj) == null ) 
            {
                Companies companies = new Companies();
                companiesDto.CNPJ = formatCnpj;
                companies.MapFromDto(companiesDto);
                _companiesRepository.createCompanies(companies);
            }
            else
            {
                throw new Exception("CNPJ already register!");
            }
            
        }

        public void deleteCompanies(string cpnj)
        {
            if (_companiesRepository.getCompanies(cpnj) != null )
            {
                _companiesRepository.deleteCompanies(cpnj);
            } 
            else
            {
                throw new Exception("Company not found!");
            }
        }

        public List<Companies> getAllCompanies()
        {
           return _companiesRepository.getAllCompanies();
        }

        public Companies getCompanies(string cnpj)
        {
            if (_companiesRepository.getCompanies(cnpj) != null)
            {
                return _companiesRepository.getCompanies(cnpj);
            }
            throw new Exception("Company not found!");
        }

        public void updateCompanies(string cnpj,CompaniesDto companiesDto)
        {
            var existingCompanies = _companiesRepository.getCompanies(cnpj);

            if (existingCompanies != null)
            {
                existingCompanies.MapFromDto(companiesDto);
                _companiesRepository.updateCompanies(existingCompanies);
            }
            else
            {
                throw new Exception("Company not found!");
            }
        }
    }
}
