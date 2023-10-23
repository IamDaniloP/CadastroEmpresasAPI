using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;
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

        public List<EntityDepartmentReturnDto> getAllDepartment()
        {
            List<Department> departmentList = _departmentRepository.getAllDepartment();

            List<EntityDepartmentReturnDto> entityDepartmentReturnList = new List<EntityDepartmentReturnDto>();
            List<EmployeeReturnDto> employeeReturnList = new List<EmployeeReturnDto>();
            List<TaskReturnDto> taskReturnList = new List<TaskReturnDto>();

            foreach (Department departmentItem in departmentList)
            {
                EntityDepartmentReturnDto entityDepartmentReturnItem = new EntityDepartmentReturnDto();
                departmentItem.Companies = _departmentRepository.getCompanies(departmentItem.CompaniesCNPJ);
                entityDepartmentReturnItem.MapFromEntityReturnDto(departmentItem);

                foreach(Employee employeeItem in departmentItem.Employees)
                {
                    EmployeeReturnDto employeeReturnItem = new EmployeeReturnDto();
                    employeeReturnItem.MapFromReturnDto(employeeItem);
                    employeeReturnList.Add(employeeReturnItem);
                }

                foreach(Model.Domain.Entities.Task taskItem in departmentItem.Tasks)
                {
                    TaskReturnDto taskReturnItem = new TaskReturnDto();
                    taskReturnItem.MapFromReturnDto(taskItem);
                    taskReturnList.Add(taskReturnItem);
                }

                entityDepartmentReturnItem.Employees = employeeReturnList;
                entityDepartmentReturnItem.Tasks = taskReturnList;

                entityDepartmentReturnList.Add(entityDepartmentReturnItem);
            }

            return entityDepartmentReturnList;
        }

        public EntityDepartmentReturnDto getDepartment(int id)
        {
            if (_departmentRepository.getDepartment(id) != null)
            {
                Department department = _departmentRepository.getDepartment(id);
                EntityDepartmentReturnDto entityDepartmentReturn = new EntityDepartmentReturnDto();

                List<EmployeeReturnDto> employeeReturnList = new List<EmployeeReturnDto>();
                List<TaskReturnDto> taskReturnList = new List<TaskReturnDto>();

                department.Companies = _departmentRepository.getCompanies(department.CompaniesCNPJ);
                entityDepartmentReturn.MapFromEntityReturnDto(department);

                foreach (Employee employeeItem in department.Employees)
                {
                    EmployeeReturnDto employeeReturnItem = new EmployeeReturnDto();
                    employeeReturnItem.MapFromReturnDto(employeeItem);
                    employeeReturnList.Add(employeeReturnItem);
                }

                foreach (Model.Domain.Entities.Task taskItem in department.Tasks)
                {
                    TaskReturnDto taskReturnItem = new TaskReturnDto();
                    taskReturnItem.MapFromReturnDto(taskItem);
                    taskReturnList.Add(taskReturnItem);
                }

                entityDepartmentReturn.Employees = employeeReturnList;
                entityDepartmentReturn.Tasks = taskReturnList;

                return entityDepartmentReturn;
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
