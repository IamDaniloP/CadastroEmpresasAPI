using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Persistence;
using CadastrosEmpresas.API.Repositories.Interfaces;

namespace CadastrosEmpresas.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ConnectionContext _connectionContext;

        public DepartmentRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void createDepartment(Department department)
        {
            _connectionContext.Departments.Add(department);
            _connectionContext.SaveChanges();
        }

        public void deleteDepartment(int id)
        {
            var department = _connectionContext.Departments.Find(id);
            if (department != null)
            {
                _connectionContext.Departments.Remove(department);
                _connectionContext.SaveChanges();
            }
        }

        public List<Department> getAllDepartment()
        {
            return _connectionContext.Departments.ToList();
        }

        public Companies getCompanies(string cnpj)
        {
            return _connectionContext.Companies.Find(cnpj);
        }

        public Department getDepartment(int id)
        {
            return _connectionContext.Departments.Find(id);
        }

        public void updateDepartment(Department department)
        {
            _connectionContext.SaveChanges();
        }

    }
}
