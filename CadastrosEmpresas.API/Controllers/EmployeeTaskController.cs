using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos;
using CadastrosEmpresas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosEmpresas.API.Controllers
{
    [ApiController]
    [Route("api/taskemployee")]
    public class EmployeeTaskController : ControllerBase
    {
        private readonly IEmployeeTaskService _employeeTaskService;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService)
        {
            _employeeTaskService = employeeTaskService;
        }

        [HttpPost]
        public IActionResult createEmployeeTask(EmployeeTaskDto employeeTaskDto)
        {
            try
            {
                _employeeTaskService.createEmployeeTask(employeeTaskDto);
                return Ok("Assignment of the task to the employee created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{taskId}/{employeeId}")]
        public IActionResult deleteEmployeeTask(Guid taskId, Guid employeeId)
        {
            try
            {
                _employeeTaskService.deleteEmployeeTask(taskId, employeeId);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{taskId}/{employeeId}")]
        public IActionResult getEmployeeTask(Guid taskId, Guid employeeId) 
        {
            try
            {
                EntityEmployeeTaskReturnDto employeeTask = _employeeTaskService.getEmployeeTask(taskId, employeeId);
                return Ok(employeeTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
