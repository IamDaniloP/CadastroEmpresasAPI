using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void createEmployee(EmployeeDto employeeDto);
        public void updateEmployee(Guid id, EmployeeDto employeeDto);
        public void deleteEmployee(Guid id);
        public EntityEmployeeReturnDto getEmployee(Guid id);
        public EntityEmployeeReturnDto getEmployeeCpf(string cpf);
        public List<EntityEmployeeReturnDto> getAllEmployees();
    }
}
