using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IDepartmentService
    {
        public void createDepartment(DepartmentDto departmentDto);
        public void updateDepartment(int id, DepartmentDto departmentDto);
        public void deleteDepartment(int id);
        public Department getDepartment(int id);
        public List<Department> getAllDepartment();
    }
}
