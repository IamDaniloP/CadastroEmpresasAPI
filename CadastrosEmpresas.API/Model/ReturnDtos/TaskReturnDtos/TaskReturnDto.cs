namespace CadastrosEmpresas.API.Model.ReturnDtos.TaskReturnDtos
{
    public class TaskReturnDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Category { get; set; }
        public Domain.Enums.TaskStatus Status { get; set; }

        public TaskReturnDto() { }

        public void MapFromReturnDto(Domain.Entities.Task task) 
        {
            Id = task.Id;
            Category = task.Category;
            TaskName = task.TaskName;
            Status = task.Status;
        }
    }
}
