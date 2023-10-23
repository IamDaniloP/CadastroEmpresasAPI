using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;
using CadastrosEmpresas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosEmpresas.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult createEmployee([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                _employeeService.createEmployee(employeeDto);
                return Ok("Employee created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult deleteEmployee(Guid id)
        {
            try
            {
                _employeeService.deleteEmployee(id);
                return Ok("Employee deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getAllEmployee()
        {
            try
            {
                List<EntityEmployeeReturnDto> employees = _employeeService.getAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getEmployee(Guid id)
        {
            try
            {
                EntityEmployeeReturnDto employee = _employeeService.getEmployee(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateDepartment(Guid id, [FromBody] EmployeeDto employeeDto)
        {
            try
            {
                if (_employeeService.getEmployee(id) != null)
                {
                    _employeeService.updateEmployee(id, employeeDto);
                }
                return Ok("Update Employee.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
