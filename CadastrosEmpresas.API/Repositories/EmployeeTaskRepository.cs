using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Persistence;
using CadastrosEmpresas.API.Repositories.Interfaces;

namespace CadastrosEmpresas.API.Repositories
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {

        private readonly ConnectionContext _connectionContext;

        public EmployeeTaskRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void createEmployeeTask(EmployeeTask employeeTask)
        {
            _connectionContext.EmployeesTask.Add(employeeTask);
            _connectionContext.SaveChanges();
        }

        public void deleteEmployeeTask(Guid taskId, Guid employeeId)
        {
            var employeeTask = _connectionContext.EmployeesTask.FirstOrDefault(key => key.TaskId == taskId && key.EmployeeId == employeeId);
            if ( employeeTask != null)
            {
                _connectionContext.EmployeesTask.Remove(employeeTask);
                _connectionContext.SaveChanges();
            }
        }

        public EmployeeTask getEmployeeTask(Guid taskId, Guid employeeId)
        {
            return _connectionContext.EmployeesTask.FirstOrDefault(key => key.TaskId == taskId && key.EmployeeId == employeeId);
        }
    }
}
