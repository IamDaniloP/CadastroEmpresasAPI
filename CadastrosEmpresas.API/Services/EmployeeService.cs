﻿using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;
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

            Companies companies = _employeeRepository.getCompanies(employeeDto.CompaniesCNPJ);
            Department department = _employeeRepository.getDepartment(employeeDto.DepartmentId);

            if (companies != null && department != null)
            {
                if (companies.CNPJ == department.CompaniesCNPJ)
                {
                    Employee employee = new Employee();
                    employeeDto.CPF = formatCpf;
                    employee.MapFromDto(employeeDto);
                    _employeeRepository.createEmployee(employee);
                } 
                else
                {
                    throw new Exception("Department don't exist in company registred");
                }
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
                List<TaskReturnDto> taskReturnList = new List<TaskReturnDto>();
                EntityEmployeeReturnDto entityEmployeeReturnItem = new EntityEmployeeReturnDto();

                employeeItem.Companies = _employeeRepository.getCompanies(employeeItem.CompaniesCNPJ);
                employeeItem.Department = _employeeRepository.getDepartment(employeeItem.DepartmentId);
                entityEmployeeReturnItem.MapFromEntityReturnDto(employeeItem);

                foreach (EmployeeTask employeeTaskItem in employeeItem.EmployeeTasks)
                {
                    TaskReturnDto taskReturnItem = new TaskReturnDto();
                    Model.Domain.Entities.Task task = _employeeRepository.getTask(employeeTaskItem.TaskId);

                    taskReturnItem.MapFromReturnDto(task);
                    taskReturnList.Add(taskReturnItem);
                }

                entityEmployeeReturnItem.EmployeeTasks = taskReturnList;
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

                List<TaskReturnDto> taskReturnList = new List<TaskReturnDto>();

                employee.Companies = _employeeRepository.getCompanies(employee.CompaniesCNPJ);
                employee.Department = _employeeRepository.getDepartment(employee.DepartmentId);
                entityEmployeeReturn.MapFromEntityReturnDto(employee);

                foreach (EmployeeTask employeeTaskItem in employee.EmployeeTasks)
                {
                    TaskReturnDto taskReturnItem = new TaskReturnDto();
                    Model.Domain.Entities.Task task = _employeeRepository.getTask(employeeTaskItem.TaskId);
                    
                    taskReturnItem.MapFromReturnDto(task);
                    taskReturnList.Add(taskReturnItem);
                }

                entityEmployeeReturn.EmployeeTasks = taskReturnList;

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

                List<TaskReturnDto> taskReturnList = new List<TaskReturnDto>();

                employee.Companies = _employeeRepository.getCompanies(employee.CompaniesCNPJ);
                employee.Department = _employeeRepository.getDepartment(employee.DepartmentId);
                entityEmployeeReturn.MapFromEntityReturnDto(employee);

                foreach (EmployeeTask employeeTaskItem in employee.EmployeeTasks)
                {
                    TaskReturnDto taskReturnItem = new TaskReturnDto();
                    Model.Domain.Entities.Task task = _employeeRepository.getTask(employeeTaskItem.TaskId);

                    taskReturnItem.MapFromReturnDto(task);
                    taskReturnList.Add(taskReturnItem);
                }

                entityEmployeeReturn.EmployeeTasks = taskReturnList;

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
