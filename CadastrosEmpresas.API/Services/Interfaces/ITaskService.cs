using CadastrosEmpresas.API.Model.Dtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface ITaskService
    {
        public void createTask(TaskDto taskDto);
        public void updateTask(Guid id, TaskDto taskDto);
        public void deleteTask(Guid id);
        public Model.Domain.Entities.Task getTask(Guid id);
        public List<Model.Domain.Entities.Task> getAllTask();
    }
}
