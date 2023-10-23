using CadastrosEmpresas.API.Model.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos;
using CadastrosEmpresas.API.Model.Domain.Enums;
using CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos;

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

        public List<EmployeeTaskFromTaskReturnDto> EmployeeTasks { get; set; }

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
