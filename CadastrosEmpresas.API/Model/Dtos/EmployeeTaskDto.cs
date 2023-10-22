using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastrosEmpresas.API.Model.Dtos
{
    public class EmployeeTaskDto
    {
        [Required]
        [JsonPropertyName("taskId")]
        public Guid TaskId { get; set; }

        [Required]
        [JsonPropertyName("employeeId")]
        public Guid EmployeeId { get; set; }

        public EmployeeTaskDto() { }

        public EmployeeTaskDto(Guid taskId, Guid employeeId)
        {
            TaskId = taskId;
            EmployeeId = employeeId;
        }
    }
}
