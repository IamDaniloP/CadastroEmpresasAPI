using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosEmpresas.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult createTask([FromBody] TaskDto taskDto)
        {
            try
            {
                _taskService.createTask(taskDto);
                return Ok("Task created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteTask(Guid id)
        {
            try
            {
                _taskService.deleteTask(id);
                return Ok("Task deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getAllTasks()
        {
            try
            {
                List<Model.Domain.Entities.Task> tasks = _taskService.getAllTask();
                return Ok(JsonSerializationHelper.SerializeObject(tasks));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getTasks(Guid id)
        {
            try
            {
                Model.Domain.Entities.Task task = _taskService.getTask(id);
                return Ok(JsonSerializationHelper.SerializeObject(task));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateDepartment(Guid id, [FromBody] TaskDto taskDto)
        {
            try
            {
                if (_taskService.getTask(id) != null)
                {
                    _taskService.updateTask(id, taskDto);
                }
                return Ok("Update Task.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
