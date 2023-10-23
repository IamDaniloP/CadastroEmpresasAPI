using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;
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
                List<EntityTaskReturnDto> tasks = _taskService.getAllTask();
                return Ok(tasks);
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
                EntityTaskReturnDto task = _taskService.getTask(id);
                return Ok(task);
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
