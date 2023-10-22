using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Repositories.Interfaces
{
    public interface ICompaniesRepository
    {
        public void createCompanies(Companies companies);
        public void updateCompanies(Companies companies);
        public void deleteCompanies(string cpnj);
        public Companies getCompanies(string cnpj);
        public List<Companies> getAllCompanies();

        public List<Department> getDepartmentCnpj(string cnpj);
        
        public List<Employee> getEmployeeCnpj(string cnpj);
    }
}
