using CadastrosEmpresas.API.Model.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastrosEmpresas.API.Model.Dtos
{
    public class TaskDto
    {
        [Required]
        public string Category { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public string TaskName { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly FinishDate { get; set; }

        [Required]
        public Model.Domain.Enums.TaskStatus Status { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public TaskDto() { }

        public TaskDto(string category, Priority priority, string taskName, DateOnly startDate, DateOnly finishDate, Model.Domain.Enums.TaskStatus status, int department)
        {
            Category = category;
            Priority = priority;
            TaskName = taskName;
            StartDate = startDate;
            FinishDate = finishDate;
            Status = status;
            DepartmentId = department;
        }
    }
}
