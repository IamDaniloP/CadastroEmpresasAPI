using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos;
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

        public List<EntityEmployeeReturnDto> getAllEmployees()
        {
            List<Employee> employeeList = _employeeRepository.getAllEmployees();

            List<EntityEmployeeReturnDto> employeeReturnList = new List<EntityEmployeeReturnDto>();

            foreach (Employee employeeItem in employeeList)
            {
                List<EmployeeTaskFromEmployeeReturnDto> employeeTaskFromEmployeeList = new List<EmployeeTaskFromEmployeeReturnDto>();
                EntityEmployeeReturnDto entityEmployeeReturnItem = new EntityEmployeeReturnDto();

                employeeItem.Companies = _employeeRepository.getCompanies(employeeItem.CompaniesCNPJ);
                employeeItem.Department = _employeeRepository.getDepartment(employeeItem.DepartmentId);
                entityEmployeeReturnItem.MapFromEntityReturnDto(employeeItem);

                foreach (EmployeeTask employeeTaskItem in employeeItem.EmployeeTasks)
                {
                    EmployeeTaskFromEmployeeReturnDto employeeTaskfromEmployeeReturnItem = new EmployeeTaskFromEmployeeReturnDto();

                    employeeTaskfromEmployeeReturnItem.MapFromReturnDto(employeeTaskItem);
                    employeeTaskFromEmployeeList.Add(employeeTaskfromEmployeeReturnItem);
                }

                entityEmployeeReturnItem.EmployeeTasks = employeeTaskFromEmployeeList;
                employeeReturnList.Add(entityEmployeeReturnItem);
            }

            return employeeReturnList;
        }

        public EntityEmployeeReturnDto getEmployee(Guid id)
        {
            if (_employeeRepository.getEmployee(id) != null)
            {
                Employee employee = _employeeRepository.getEmployee(id);

                EntityEmployeeReturnDto entityEmployeeReturn = new EntityEmployeeReturnDto();

                List<EmployeeTaskFromEmployeeReturnDto> employeeTaskFromEmployeeList = new List<EmployeeTaskFromEmployeeReturnDto>();

                employee.Companies = _employeeRepository.getCompanies(employee.CompaniesCNPJ);
                employee.Department = _employeeRepository.getDepartment(employee.DepartmentId);
                entityEmployeeReturn.MapFromEntityReturnDto(employee);

                foreach (EmployeeTask employeeTaskItem in employee.EmployeeTasks)
                {
                    EmployeeTaskFromEmployeeReturnDto employeeTaskfromEmployeeReturnItem = new EmployeeTaskFromEmployeeReturnDto();

                    employeeTaskfromEmployeeReturnItem.MapFromReturnDto(employeeTaskItem);
                    employeeTaskFromEmployeeList.Add(employeeTaskfromEmployeeReturnItem);
                }

                entityEmployeeReturn.EmployeeTasks = employeeTaskFromEmployeeList;

                return entityEmployeeReturn;
            }
            throw new Exception("Employee not found.");
        }

        public EntityEmployeeReturnDto getEmployeeCpf(string cpf)
        {
            if (_employeeRepository.getEmployeeCpf(cpf) != null)
            {
                Employee employee = _employeeRepository.getEmployeeCpf(cpf);

                EntityEmployeeReturnDto entityEmployeeReturn = new EntityEmployeeReturnDto();

                List<EmployeeTaskFromEmployeeReturnDto> employeeTaskFromEmployeeList = new List<EmployeeTaskFromEmployeeReturnDto>();

                employee.Companies = _employeeRepository.getCompanies(employee.CompaniesCNPJ);
                employee.Department = _employeeRepository.getDepartment(employee.DepartmentId);
                entityEmployeeReturn.MapFromEntityReturnDto(employee);

                foreach (EmployeeTask employeeTaskItem in employee.EmployeeTasks)
                {
                    EmployeeTaskFromEmployeeReturnDto employeeTaskfromEmployeeReturnItem = new EmployeeTaskFromEmployeeReturnDto();

                    employeeTaskfromEmployeeReturnItem.MapFromReturnDto(employeeTaskItem);
                    employeeTaskFromEmployeeList.Add(employeeTaskfromEmployeeReturnItem);
                }

                entityEmployeeReturn.EmployeeTasks = employeeTaskFromEmployeeList;

                return entityEmployeeReturn;
            }
            throw new Exception("Employee not found.");
        }

        public void updateEmployee(Guid id, EmployeeDto employeeDto)
        {
            var existingEmployee = _employeeRepository.getEmployee(id);

            if (existingEmployee != null)
            {
                employeeDto.CPF = employeeDto.CPF.Replace(".", "");
                employeeDto.CPF = employeeDto.CPF.Replace("-", "");

                employeeDto.CompaniesCNPJ = existingEmployee.CompaniesCNPJ;
                employeeDto.DepartmentId = existingEmployee.DepartmentId;
                //employeeDto.CPF = existingEmployee.CPF; -> só irá permitir caso o cpf ainda permaneça o mesmo
                existingEmployee.MapFromDto(employeeDto);
                _employeeRepository.updateEmployee(existingEmployee);
            }
            else
            {
                throw new Exception("Employee not found!");
            }
        }
    }
}
