using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Services.Interfaces;

namespace CadastrosEmpresas.API.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void createEmployee(EmployeeDto employeeDto)
        {

            string formatCpf = employeeDto.CPF;
            formatCpf = formatCpf.Replace(".", "");
            formatCpf = formatCpf.Replace("-", "");

            if (_employeeRepository.getCompanies(employeeDto.CompaniesCNPJ) != null
                && _employeeRepository.getDepartment(employeeDto.DepartmentId) != null)
            {
                Employee employee = new Employee();
                employeeDto.CPF = formatCpf;
                employee.MapFromDto(employeeDto);
                _employeeRepository.createEmployee(employee);
            } 
            else 
            {
                throw new Exception("CNPJ or DepartmentId invalid.");
            }
        }

        public void deleteEmployee(Guid id)
        {
            if (_employeeRepository.getEmployee(id) != null)
            {
                _employeeRepository.deleteEmployee(id);
            }
            else
            {
                throw new Exception("Employee not found.");
            }
        }

        public List<Employee> getAllEmployees()
        {
            return _employeeRepository.getAllEmployees();
        }

        public Employee getEmployee(Guid id)
        {
            if (_employeeRepository.getEmployee(id) != null)
            {
                return _employeeRepository.getEmployee(id);
            }
            throw new Exception("Department not found.");
        }

        public void updateEmployee(Guid id, EmployeeDto employeeDto)
        {
            var existingEmployee = _employeeRepository.getEmployee(id);

            if (existingEmployee != null)
            {
                employeeDto.CompaniesCNPJ = existingEmployee.CompaniesCNPJ;
                employeeDto.DepartmentId = existingEmployee.DepartmentId;
                existingEmployee.MapFromDto(employeeDto);
                _employeeRepository.updateEmployee(existingEmployee);
            }
            else
            {
                throw new Exception("Department not found!");
            }
        }
    }
}
