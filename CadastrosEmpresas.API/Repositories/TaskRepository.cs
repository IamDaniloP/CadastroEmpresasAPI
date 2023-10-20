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
            return _connectionContext.Tasks.ToList();
        }

        public Department getDepartment(int id)
        {
            return _connectionContext.Departments.Find(id);
        }

        public Model.Domain.Entities.Task getTask(Guid id)
        {
            return _connectionContext.Tasks.Find(id);
        }

        public void updateTask(Model.Domain.Entities.Task task)
        {
            _connectionContext.SaveChanges();
        }
    }
}
