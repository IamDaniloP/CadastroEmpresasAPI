using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IDepartmentService
    {
        public void createDepartment(DepartmentDto departmentDto);
        public void updateDepartment(int id, DepartmentDto departmentDto);
        public void deleteDepartment(int id);
        public EntityDepartmentReturnDto getDepartment(int id);
        public List<EntityDepartmentReturnDto> getAllDepartment();
    }
}
