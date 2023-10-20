using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Services.Interfaces;

namespace CadastrosEmpresas.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void createDepartment(DepartmentDto departmentDto)
        {
            if (_departmentRepository.getCompanies(departmentDto.CompaniesCNPJ) != null)
            {
                Department department = new Department();
                department.MapFromDto(departmentDto);
                _departmentRepository.createDepartment(department);
            }
            else
            {
                throw new Exception("CNPJ dont found");
            }
        }

        public void deleteDepartment(int id)
        {
            if (_departmentRepository.getDepartment(id) != null)
            {
                _departmentRepository.deleteDepartment(id);
            }
            else
            {
                throw new Exception("Department not found.");
            }
        }

        public List<Department> getAllDepartment()
        {
            return _departmentRepository.getAllDepartment();
        }

        public Department getDepartment(int id)
        {
            if (_departmentRepository.getDepartment(id) != null)
            {
                return _departmentRepository.getDepartment(id);
            }
            throw new Exception("Department not found.");
        }

        public void updateDepartment(int id, DepartmentDto departmentDto)
        {
            var existingDepartment = _departmentRepository.getDepartment(id);

            if (existingDepartment != null)
            {
                departmentDto.CompaniesCNPJ = existingDepartment.CompaniesCNPJ;
                existingDepartment.MapFromDto(departmentDto);
                _departmentRepository.updateDepartment(existingDepartment);
            }
            else
            {
                throw new Exception("Department not found.");
            }
        }
    }
}
