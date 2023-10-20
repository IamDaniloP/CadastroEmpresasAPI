using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Repositories.Interfaces;
using CadastrosEmpresas.API.Services.Interfaces;

namespace CadastrosEmpresas.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void createTask(TaskDto taskDto)
        {
            if (_taskRepository.getDepartment(taskDto.DepartmentId) != null)
            {
                Model.Domain.Entities.Task task = new Model.Domain.Entities.Task();
                task.MapFromDto(taskDto);
                _taskRepository.createTask(task);
            }
            else
            {
                throw new Exception("Department not found.");
            }
        }

        public void deleteTask(Guid id)
        {
            if (_taskRepository.getTask(id) != null)
            {
                _taskRepository.deleteTask(id);
            }
            else
            {
                throw new Exception("Task not found.");
            }
        }

        public List<Model.Domain.Entities.Task> getAllTask()
        {
            return _taskRepository.getAllTask();
        }

        public Model.Domain.Entities.Task getTask(Guid id)
        {
            if (_taskRepository.getTask(id) != null)
            {
                return _taskRepository.getTask(id);
            }
            throw new Exception("Task not found.");
        }

        public void updateTask(Guid id, TaskDto taskDto)
        {
            var existingTask = _taskRepository.getTask(id);

            if(existingTask != null)
            {
                taskDto.DepartmentId = existingTask.DepartmentId;
                existingTask.MapFromDto(taskDto);
                _taskRepository.updateTask(existingTask);
            }
            else
            {
                throw new Exception("Task not found.");
            }
        }
    }
}
