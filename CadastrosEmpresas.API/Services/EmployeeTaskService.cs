using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
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
            try
            {
                EmployeeTask employeeTask = new EmployeeTask();
                employeeTask.MapFromDto(employeeTaskDto);
                _employeeTaskRepository.createEmployeeTask(employeeTask);
            }
            catch (Exception ex)
            {
                throw new Exception($"Employee or Task not found:\n{ex.Message}");
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

        public EmployeeTask getEmployeeTask(Guid taskId, Guid employeeId)
        {
            if (_employeeTaskRepository.getEmployeeTask(taskId, employeeId) != null)
            {
                return _employeeTaskRepository.getEmployeeTask(taskId, employeeId);
            }
            else
            {
                throw new Exception("EmployeeTask not fund");
            }
        }
    }
}
