using CadastrosEmpresas.API.Model.Domain.Entities;
using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosEmpresas.API.Controllers
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public IActionResult createDepartment([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                _departmentService.createDepartment(departmentDto);
                return Ok("Department created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteDepartment(int id)
        {
            try
            {
                _departmentService.deleteDepartment(id);
                return Ok("Department deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getAllDepartment() 
        {
            try
            {
                List<Department> departments = _departmentService.getAllDepartment();
                return Ok(JsonSerializationHelper.SerializeObject(departments));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult getDepartment(int id)
        {
            try
            {
                Department department = _departmentService.getDepartment(id);
                return Ok(JsonSerializationHelper.SerializeObject(department));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateDepartment(int id, [FromBody] DepartmentDto departmentDto)
        {
            try
            {
                if (_departmentService.getDepartment(id) != null)
                {
                    _departmentService.updateDepartment(id, departmentDto);
                }
                return Ok("Update Department.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
