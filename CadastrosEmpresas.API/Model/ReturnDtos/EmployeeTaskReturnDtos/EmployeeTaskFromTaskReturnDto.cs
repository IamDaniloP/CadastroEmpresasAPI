using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Model.ReturnDtos.EmployeeTaskReturnDtos
{
    public class EmployeeTaskFromTaskReturnDto
    {
        public Guid EmployeeId { get; set; }

        public EmployeeTaskFromTaskReturnDto() { }

        public void MapFromReturnDto(EmployeeTask employeeTask)
        {
            EmployeeId = employeeTask.EmployeeId;
        }
    }
}
