using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        public void createDepartment(Department department);
        public Companies getCompanies(string cnpj);
        public void updateDepartment(Department department);
        public void deleteDepartment(int id);
        public Department getDepartment(int id);
        public List<Department> getAllDepartment();
    }
}
