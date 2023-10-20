using CadastrosEmpresas.API.Model.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastrosEmpresas.API.Model.Domain.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }
        public Enums.Priority Priority { get; set; }
        public string TaskName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinishDate { get; set; }
        public Enums.TaskStatus Status { get; set; }


        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<EmployeeTask> EmployeeTasks { get; set; }

        public Task()
        {
            Id = Guid.NewGuid();
            EmployeeTasks = new List<EmployeeTask>();
        }

        public void MapFromDto(TaskDto taskDto)
        {
            Category = taskDto.Category;
            Priority = taskDto.Priority;
            TaskName = taskDto.TaskName;
            StartDate = taskDto.StartDate;
            FinishDate = taskDto.FinishDate;
            Status = taskDto.Status;
            DepartmentId = taskDto.DepartmentId;
        }
    }
}
