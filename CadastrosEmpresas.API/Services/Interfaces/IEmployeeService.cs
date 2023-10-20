using CadastrosEmpresas.API.Model.Dtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        public void createEmployee(EmployeeDto employeeDto);
        public void updateEmployee(Guid id, EmployeeDto employeeDto);
        public void deleteEmployee(Guid id);
        public Employee getEmployee(Guid id);
        public List<Employee> getAllEmployees();
    }
}
