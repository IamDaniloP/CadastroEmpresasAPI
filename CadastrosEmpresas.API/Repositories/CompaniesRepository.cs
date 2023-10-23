using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Persistence;
using CadastrosEmpresas.API.Repositories.Interfaces;

namespace CadastrosEmpresas.API.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    { 
        private readonly ConnectionContext _connectionContext;

        public CompaniesRepository (ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void createCompanies(Companies companies)
        {
            _connectionContext.Companies.Add(companies);
            _connectionContext.SaveChanges();
        }

        public void deleteCompanies(string cnpj)
        {
            var companies = _connectionContext.Companies.Find(cnpj);
            if (companies != null)
            {
                _connectionContext.Companies.Remove(companies);
                _connectionContext.SaveChanges();
            }
        }

        public List<Companies> getAllCompanies()
        {
            var campaniesList = _connectionContext.Companies.ToList();

            foreach (Companies companies in campaniesList)
            {
                companies.Departments = getDepartmentCnpj(companies.CNPJ);
                companies.Employees = getEmployeeCnpj(companies.CNPJ);
            }

            return campaniesList;
        }

        public Companies getCompanies(string cnpj)
        {
            Companies companies = _connectionContext.Companies.Find(cnpj);

            if (companies != null)
            {
                companies.Departments = getDepartmentCnpj(cnpj);
                companies.Employees = getEmployeeCnpj(cnpj);
            }
            
            return companies;
        }

        public List<Department> getDepartmentCnpj(string cnpj)
        {
            var departments = _connectionContext.Departments
                .Where(d => d.CompaniesCNPJ == cnpj)
                .ToList();

            return departments;
        }

        public List<Employee> getEmployeeCnpj(string cnpj)
        {
            var employees = _connectionContext.Employees
                .Where(e => e.CompaniesCNPJ == cnpj)
                .ToList();

            return employees;
        }

        public void updateCompanies(Companies companies)
        {
            _connectionContext.SaveChanges();
        }
    }
}
