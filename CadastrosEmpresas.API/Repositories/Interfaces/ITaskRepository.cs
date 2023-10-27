using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public void createTask(Model.Domain.Entities.Task task);
        public void updateTask(Model.Domain.Entities.Task task);
        public void deleteTask(Guid id);
        public Model.Domain.Entities.Task getTask(Guid id);
        public List<Model.Domain.Entities.Task> getAllTask();

        public Department getDepartment(int id);

        public List<EmployeeTask> getEmployeeTaskTaskId(Guid taskId);
        public Employee getEmployee(Guid employeeId);
    }
}
