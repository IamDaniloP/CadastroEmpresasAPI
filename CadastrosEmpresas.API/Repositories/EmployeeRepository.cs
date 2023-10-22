﻿using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Persistence;
using CadastrosEmpresas.API.Repositories.Interfaces;

namespace CadastrosEmpresas.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _connectionContext;
        
        public EmployeeRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void createEmployee(Employee employee)
        {
            _connectionContext.Employees.Add(employee);
            _connectionContext.SaveChanges();
        }

        public void deleteEmployee(Guid id)
        {
            var employee = _connectionContext.Employees.Find(id);
            if (employee != null)
            {
                _connectionContext.Employees.Remove(employee); 
                _connectionContext.SaveChanges();
            }
        }

        public List<Employee> getAllEmployees()
        {
            var employees = _connectionContext.Employees.ToList();

            foreach (Employee employee in employees)
            {
                //employee.Companies = getCompanies(employee.CompaniesCNPJ);
                //employee.Department = getDepartment(employee.DepartmentId);
                employee.EmployeeTasks = getEmployeeTaskEmployeeId(employee.Id);
            }

            return employees;
        }

        public Companies getCompanies(string cnpj)
        {
            return _connectionContext.Companies.Find(cnpj);
        }

        public Department getDepartment(int id)
        {
            return _connectionContext.Departments.Find(id);
        }

        public Employee getEmployee(Guid id)
        {
            Employee employee = _connectionContext.Employees.Find(id);
            
            if (employee != null)
            {
                //employee.Companies = getCompanies(employee.CompaniesCNPJ);
                //employee.Department = getDepartment(employee.DepartmentId);
                employee.EmployeeTasks = getEmployeeTaskEmployeeId(id);
            }

            return employee;
        }

        public List<EmployeeTask> getEmployeeTaskEmployeeId(Guid employeeId)
        {
            var employeeTasks = _connectionContext.EmployeesTask
                .Where(et => et.EmployeeId == employeeId)
                .ToList();

            return employeeTasks;
        }

        public void updateEmployee(Employee employee)
        {
            _connectionContext.SaveChanges();
        }
    }
}
