using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IEmployeeTaskService
    {
        public void createEmployeeTask(EmployeeTaskDto employeeTaskDto);
        public void deleteEmployeeTask(Guid taskId, Guid employeeId);
        public EmployeeTask getEmployeeTask(Guid taskId, Guid employeeId);
    }
}
