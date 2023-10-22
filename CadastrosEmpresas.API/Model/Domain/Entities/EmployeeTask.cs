using CadastrosEmpresas.API.Model.Dtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastrosEmpresas.API.Model.Domain.Entities
{
    public class EmployeeTask
    {
        [ForeignKey("TaskId")]
        public Guid TaskId { get; set; }
        public Task Task { get; set; }

        [ForeignKey("EmployeeId")]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    
        public EmployeeTask() { }

        public void MapFromDto(EmployeeTaskDto employeeTaskDto)
        {
            TaskId = employeeTaskDto.TaskId;
            EmployeeId = employeeTaskDto.EmployeeId;
        }
    }
}
