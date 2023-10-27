using CadastrosEmpresas.API.Model.Domain.Enums;
using CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos;

namespace CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos
{
    public class EntityTaskReturnDto
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public Priority Priority { get; set; }
        public string TaskName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly FinishDate { get; set; }
        public Model.Domain.Enums.TaskStatus Status { get; set; }

        public DepartmentReturnDto Department { get; set; }

        public List<EmployeeReturnDto> TasksEmployee { get; set; }

        public EntityTaskReturnDto() { }

        public void MapFromEntityReturnDto(Model.Domain.Entities.Task task)
        {
            Id = task.Id;
            Category = task.Category;
            Priority = task.Priority;
            TaskName = task.TaskName;
            StartDate = task.StartDate;
            FinishDate = task.FinishDate;
            Status = task.Status;

            Department = new DepartmentReturnDto();
            Department.MapFromReturnDto(task.Department);
        }
    }
}
