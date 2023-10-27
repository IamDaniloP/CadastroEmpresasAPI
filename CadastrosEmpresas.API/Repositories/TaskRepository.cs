using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Persistence;
using CadastrosEmpresas.API.Repositories.Interfaces;

namespace CadastrosEmpresas.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ConnectionContext _connectionContext;

        public TaskRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void createTask(Model.Domain.Entities.Task task)
        {
            _connectionContext.Tasks.Add(task);
            _connectionContext.SaveChanges();
        }

        public void deleteTask(Guid id)
        {
            var task = _connectionContext.Tasks.Find(id);
            if (task != null)
            {
                _connectionContext.Tasks.Remove(task);
                _connectionContext.SaveChanges();
            }
        }

        public List<Model.Domain.Entities.Task> getAllTask()
        {
            var tasks = _connectionContext.Tasks.ToList();

            foreach (Model.Domain.Entities.Task task in tasks)
            {
                task.EmployeeTasks = getEmployeeTaskTaskId(task.Id);
            }

            return tasks;
        }

        public Department getDepartment(int id)
        {
            return _connectionContext.Departments.Find(id);
        }

        public Employee getEmployee(Guid employeeId)
        {
            return _connectionContext.Employees.Find(employeeId);
        }

        public List<EmployeeTask> getEmployeeTaskTaskId(Guid taskId)
        {
            var employeeTasks = _connectionContext.EmployeesTask
                .Where(et => et.TaskId == taskId)
                .ToList();

            return employeeTasks;
        }

        public Model.Domain.Entities.Task getTask(Guid id)
        {
            var task = _connectionContext.Tasks.Find(id);

            if ( task != null )
            {
                task.EmployeeTasks = getEmployeeTaskTaskId(id);
            }
            
            return task;
        }

        public void updateTask(Model.Domain.Entities.Task task)
        {
            _connectionContext.SaveChanges();
        }
    }
}
