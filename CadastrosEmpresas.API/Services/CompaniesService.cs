using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.CompaniesReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Services.Interfaces;

namespace CadastrosEmpresas.API.Services
{
    public class CompaniesService : IcompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;

        public CompaniesService(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public void createCompanies(CompaniesDto companiesDto)
        {
            string formatCnpj = companiesDto.CNPJ;
            formatCnpj = formatCnpj.Replace(".", "");
            formatCnpj = formatCnpj.Replace("/", "");
            formatCnpj = formatCnpj.Replace("-", "");

            if (_companiesRepository.getCompanies(formatCnpj) == null)
            {
                Companies companies = new Companies();
                companiesDto.CNPJ = formatCnpj;
                companies.MapFromDto(companiesDto);
                _companiesRepository.createCompanies(companies);
            }
            else
            {
                throw new Exception("CNPJ already register!");
            }

        }

        public void deleteCompanies(string cpnj)
        {
            if (_companiesRepository.getCompanies(cpnj) != null)
            {
                _companiesRepository.deleteCompanies(cpnj);
            }
            else
            {
                throw new Exception("Company not found!");
            }
        }

        public List<EntityCompaniesReturnDto> getAllCompanies()
        {
            List<Companies> companiesList = _companiesRepository.getAllCompanies();

            List<EntityCompaniesReturnDto> entityCompaniesReturnList = new List<EntityCompaniesReturnDto>();
            List<EmployeeReturnDto> employeeReturnList = new List<EmployeeReturnDto>();
            List<DepartmentReturnDto> departmentReturnList = new List<DepartmentReturnDto>();

            foreach (Companies companiesItem in companiesList)
            {
                EntityCompaniesReturnDto entityCompaniesReturnItem = new EntityCompaniesReturnDto();
                entityCompaniesReturnItem.MapFromEntityReturnDto(companiesItem);

                foreach (Employee employeeItem in companiesItem.Employees)
                {
                    EmployeeReturnDto employeeReturnItem = new EmployeeReturnDto();
                    employeeReturnItem.MapFromReturnDto(employeeItem);
                    employeeReturnList.Add(employeeReturnItem);
                }

                foreach (Department departmentItem in companiesItem.Departments)
                {
                    DepartmentReturnDto departmentReturnItem = new DepartmentReturnDto();
                    departmentReturnItem.MapFromReturnDto(departmentItem);
                    departmentReturnList.Add(departmentReturnItem);
                }

                entityCompaniesReturnItem.Employees = employeeReturnList;
                entityCompaniesReturnItem.Departments = departmentReturnList;

                entityCompaniesReturnList.Add(entityCompaniesReturnItem);
            }

            return entityCompaniesReturnList;
        }

        public EntityCompaniesReturnDto getCompanies(string cnpj)
        {
            if (_companiesRepository.getCompanies(cnpj) != null)
            {

                Companies companies = _companiesRepository.getCompanies(cnpj);

                EntityCompaniesReturnDto entityCompaniesReturn = new EntityCompaniesReturnDto();
                List<EmployeeReturnDto> employeeReturnList = new List<EmployeeReturnDto>();
                List<DepartmentReturnDto> departmentReturnList = new List<DepartmentReturnDto>();

                entityCompaniesReturn.MapFromEntityReturnDto(companies);
                foreach (Employee employeeItem in companies.Employees)
                {
                    EmployeeReturnDto employeeReturnItem = new EmployeeReturnDto();
                    employeeReturnItem.MapFromReturnDto(employeeItem);
                    employeeReturnList.Add(employeeReturnItem);
                }

                foreach (Department departmentItem in companies.Departments)
                {
                    DepartmentReturnDto departmentReturnItem = new DepartmentReturnDto();
                    departmentReturnItem.MapFromReturnDto(departmentItem);
                    departmentReturnList.Add(departmentReturnItem);
                }

                entityCompaniesReturn.Employees = employeeReturnList;
                entityCompaniesReturn.Departments = departmentReturnList;

                return entityCompaniesReturn;
            }
            throw new Exception("Company not found!");
        }

        public void updateCompanies(string cnpj, CompaniesDto companiesDto)
        {
            var existingCompanies = _companiesRepository.getCompanies(cnpj);

            if (existingCompanies != null)
            {
                existingCompanies.MapFromDto(companiesDto);
                _companiesRepository.updateCompanies(existingCompanies);
            }
            else
            {
                throw new Exception("Company not found!");
            }
        }
    }
}
