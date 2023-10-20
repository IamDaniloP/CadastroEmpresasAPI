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
            return _connectionContext.Companies.ToList();
        }

        public Companies getCompanies(string cnpj)
        {
            return _connectionContext.Companies.Find(cnpj);
        }

        public void updateCompanies(Companies companies)
        {
            _connectionContext.SaveChanges();
        }
    }
}
