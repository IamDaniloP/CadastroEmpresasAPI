using CadastrosEmpresas.API.Model.Dtos;
using CadastrosEmpresas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastrosEmpresas.API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        private readonly IcompaniesService _companiesService;
        
        public CompaniesController(IcompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpPost]
        public IActionResult createCompanies([FromBody] CompaniesDto companiesDto)
        {
            try
            {
                _companiesService.createCompanies(companiesDto);
                return Ok("Company created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cnpj}")]
        public IActionResult deleteCompanies(string cnpj)
        {
            try {
                _companiesService.deleteCompanies(cnpj);
                return Ok("Company deleted.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getAllCompanies()
        {
            try
            {
                List<Companies> companiesList = _companiesService.getAllCompanies();
                return Ok(JsonSerializationHelper.SerializeObject(companiesList));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{cnpj}")]
        public IActionResult getCompanies(string cnpj)
        {
            try
            {
                Companies companies = _companiesService.getCompanies(cnpj);
                return Ok(JsonSerializationHelper.SerializeObject(companies));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{cnpj}")]
        public IActionResult updateCompanies(string cnpj, [FromBody] CompaniesDto companiesDto)
        {
            try 
            {
                if (_companiesService.getCompanies(cnpj) != null)
                {
                    _companiesService.updateCompanies(cnpj, companiesDto);
                }
                return Ok("Update Company.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
