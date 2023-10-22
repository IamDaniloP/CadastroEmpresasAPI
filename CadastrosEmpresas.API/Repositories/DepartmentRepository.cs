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
            var departments = _connectionContext.Departments.ToList();

            foreach (Department department in departments)
            {
                //department.Companies = getCompanies(department.CompaniesCNPJ);
                department.Employees = getEmployeesDepartmentId(department.Id);
                department.Tasks = getTasksDepartmentId(department.Id);
            }

            return departments;
        }

        public Companies getCompanies(string cnpj)
        {
            return _connectionContext.Companies.Find(cnpj);
        }

        public Department getDepartment(int id)
        {
            Department department = _connectionContext.Departments.Find(id);
            if (department != null )
            {
                //department.Companies = getCompanies(department.CompaniesCNPJ);
                department.Employees = getEmployeesDepartmentId(department.Id);
                department.Tasks = getTasksDepartmentId(department.Id);
            }

            return department;
        }

        public List<Employee> getEmployeesDepartmentId(int id)
        {
            var employees = _connectionContext.Employees
                .Where(e => e.DepartmentId == id)
                .ToList();

            return employees;
        }

        public List<Model.Domain.Entities.Task> getTasksDepartmentId(int id)
        {
            var tasks = _connectionContext.Tasks
                .Where(t => t.DepartmentId == id)
                .ToList();

            return tasks;
        }

        public void updateDepartment(Department department)
        {
            _connectionContext.SaveChanges();
        }

    }
}
