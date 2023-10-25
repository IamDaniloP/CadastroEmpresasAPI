using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Services.Interfaces;

namespace CadastrosEmpresas.API.Services
{
    public class EmployeeTaskService : IEmployeeTaskService
    {
        private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public EmployeeTaskService(IEmployeeTaskRepository employeeTaskRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }

        public void createEmployeeTask(EmployeeTaskDto employeeTaskDto)
        {
            Employee employee = _employeeTaskRepository.getEmployee(employeeTaskDto.EmployeeId);
            Model.Domain.Entities.Task task = _employeeTaskRepository.GetTask(employeeTaskDto.TaskId);

            if (employee != null && task != null)
            {
                if (employee.DepartmentId == task.DepartmentId)
                {
                    EmployeeTask employeeTask = new EmployeeTask();
                    employeeTask.MapFromDto(employeeTaskDto);
                    _employeeTaskRepository.createEmployeeTask(employeeTask);
                }
                else
                {
                    throw new Exception("Employee and Task don't belong to the same department.");
                }
            }
            else
            {
                throw new Exception("Employee or Task not found");
            }
        }

        public void deleteEmployeeTask(Guid taskId, Guid employeeId)
        {
            if (_employeeTaskRepository.getEmployeeTask(taskId, employeeId) != null)
            {
                _employeeTaskRepository.deleteEmployeeTask(taskId, employeeId);
            }
            else
            {
                throw new Exception("Employee or Task not found.");
            }
        }

        public EntityEmployeeTaskReturnDto getEmployeeTask(Guid taskId, Guid employeeId)
        {
            EmployeeTask employeeTask = _employeeTaskRepository.getEmployeeTask(taskId, employeeId);

            if (employeeTask != null)
            {
                EntityEmployeeTaskReturnDto entityEmployeeTaskReturnDto = new EntityEmployeeTaskReturnDto();

                Model.Domain.Entities.Task task = _employeeTaskRepository.GetTask(taskId);
                Employee employee = _employeeTaskRepository.getEmployee(employeeId);

                entityEmployeeTaskReturnDto.MapFromEntityReturnDto(task, employee);

                return entityEmployeeTaskReturnDto;
            }
            else
            {
                throw new Exception("Employee or Task not found.");
            }
        }
    }
}
