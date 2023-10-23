using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos
{
    public class EmployeeTaskFromEmployeeReturnDto
    {
        public Guid TaskId { get; set; }

        public EmployeeTaskFromEmployeeReturnDto() { }

        public void MapFromReturnDto(EmployeeTask employeeTask)
        {
            TaskId = employeeTask.TaskId;
        }
    }
}
