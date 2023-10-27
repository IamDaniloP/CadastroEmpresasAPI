using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos;
using System.Text.Json.Serialization;

namespace CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos
{
    public class EntityEmployeeTaskReturnDto
    {
        [JsonPropertyName("Task")]
        public TaskReturnDto TaskReturnDto { get; set; }

        [JsonPropertyName("Employee")]
        public EmployeeReturnDto EmployeeReturnDto { get; set; }

        public EntityEmployeeTaskReturnDto() { }
        public void MapFromEntityReturnDto(Domain.Entities.Task task, Employee employee)
        {
            TaskReturnDto = new TaskReturnDto();
            TaskReturnDto.MapFromReturnDto(task);

            EmployeeReturnDto = new EmployeeReturnDto();
            EmployeeReturnDto.MapFromReturnDto(employee);
        }
    }
}