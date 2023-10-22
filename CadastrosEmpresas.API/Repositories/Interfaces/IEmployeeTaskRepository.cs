using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Repositories.Interfaces
{
    public interface IEmployeeTaskRepository
    {
        public void createEmployeeTask(EmployeeTask employeeTask);
        public void deleteEmployeeTask(Guid taskId, Guid employeeId);
        public EmployeeTask getEmployeeTask(Guid taskId, Guid employeeId);
    }
}
