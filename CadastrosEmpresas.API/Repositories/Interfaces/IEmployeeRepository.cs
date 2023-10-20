﻿using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public void createEmployee(Employee employee);
        public Employee getEmployee(Guid id);
        public void updateEmployee(Employee employee);
        public void deleteEmployee(Guid id);
        public List<Employee> getAllEmployees();

        public Department getDepartment(int id);
        public Companies getCompanies(string cnpj);
    }
}