using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;
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

        public List<EntityTaskReturnDto> getAllTask()
        {
            List<Model.Domain.Entities.Task> taskList = _taskRepository.getAllTask();
            List<EntityTaskReturnDto> entityTaskReturnList = new List<EntityTaskReturnDto>();

            foreach (Model.Domain.Entities.Task taskItem in taskList)
            {
                List<EmployeeTaskFromTaskReturnDto> employeeTaskFromTaskReturnList = new List<EmployeeTaskFromTaskReturnDto>();
                EntityTaskReturnDto entityTaskReturnItem = new EntityTaskReturnDto();

                taskItem.Department = _taskRepository.getDepartment(taskItem.DepartmentId);
                entityTaskReturnItem.MapFromEntityReturnDto(taskItem);

                foreach (EmployeeTask employeeTaskItem in taskItem.EmployeeTasks)
                {
                    EmployeeTaskFromTaskReturnDto employeeTaskFromTaskReturnItem = new EmployeeTaskFromTaskReturnDto();

                    employeeTaskFromTaskReturnItem.MapFromReturnDto(employeeTaskItem);
                    employeeTaskFromTaskReturnList.Add(employeeTaskFromTaskReturnItem);
                }

                entityTaskReturnItem.EmployeeTasks = employeeTaskFromTaskReturnList;
                entityTaskReturnList.Add(entityTaskReturnItem);
            }

            return entityTaskReturnList;
        }

        public EntityTaskReturnDto getTask(Guid id)
        {
            if (_taskRepository.getTask(id) != null)
            {
                Model.Domain.Entities.Task task = _taskRepository.getTask(id);

                EntityTaskReturnDto entityTaskReturn = new EntityTaskReturnDto();

                List<EmployeeTaskFromTaskReturnDto> employeeTaskFromTaskReturnList = new List<EmployeeTaskFromTaskReturnDto>();
                
                task.Department = _taskRepository.getDepartment(task.DepartmentId);
                entityTaskReturn.MapFromEntityReturnDto(task);

                foreach (EmployeeTask employeeTaskItem in task.EmployeeTasks)
                {
                    EmployeeTaskFromTaskReturnDto employeeTaskFromTaskItem = new EmployeeTaskFromTaskReturnDto();

                    employeeTaskFromTaskItem.MapFromReturnDto(employeeTaskItem);
                    employeeTaskFromTaskReturnList.Add(employeeTaskFromTaskItem);
                }

                entityTaskReturn.EmployeeTasks = employeeTaskFromTaskReturnList;

                return entityTaskReturn;
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
