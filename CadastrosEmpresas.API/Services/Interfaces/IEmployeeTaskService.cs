using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface IEmployeeTaskService
    {
        public void createEmployeeTask(EmployeeTaskDto employeeTaskDto);
        public void deleteEmployeeTask(Guid taskId, Guid employeeId);
        public EntityEmployeeTaskReturnDto getEmployeeTask(Guid taskId, Guid employeeId);
    }
}
