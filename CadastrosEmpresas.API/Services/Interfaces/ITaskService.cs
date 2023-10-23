using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;

namespace CadastrosEmpresas.API.Services.Interfaces
{
    public interface ITaskService
    {
        public void createTask(TaskDto taskDto);
        public void updateTask(Guid id, TaskDto taskDto);
        public void deleteTask(Guid id);
        public EntityTaskReturnDto getTask(Guid id);
        public List<EntityTaskReturnDto> getAllTask();
    }
}
