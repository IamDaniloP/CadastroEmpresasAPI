using CadastrosEmpresas.API.Model.Domain.Entities;

namespace CadastrosEmpresas.API.Model.ReturnDtos.DepartmentReturnDtos
{
    public class DepartmentReturnDto
    {
        public string DepartmentName { get; set; }
        public string HeadOfTheDepartment { get; set; }

        public DepartmentReturnDto() { }

        public void MapFromReturnDto(Department department)
        {
            DepartmentName = department.DepartmentName;
            HeadOfTheDepartment = department.HeadOfTheDepartment;
        }
    }
}
