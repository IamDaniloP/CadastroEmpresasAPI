namespace CadastrosEmpresas.API.Model.ReturnDtos.EmployeeReturnDtos
{
    public class EmployeeReturnDto
    {
        public Guid Id { get; set; }
        public string NameEmployee { get; set; }
        public string CPF {  get; set; }

        public EmployeeReturnDto() { }

        public void MapFromReturnDto(Employee employee)
        {
            Id = employee.Id;
            NameEmployee = employee.NameEmployee;
            CPF = employee.CPF;
        }
    }
}
