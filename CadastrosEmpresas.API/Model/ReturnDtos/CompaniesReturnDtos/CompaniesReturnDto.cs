namespace CadastrosEmpresas.API.Model.ReturnDtos.CompaniesReturnDtos
{
    public class CompaniesReturnDto
    {
        public string CompaniesName { get; set; }
        public string CEO {  get; set; }
        public string CNPJ { get; set; }

        public CompaniesReturnDto() { }

        public void MapFromReturnDto(Companies companies)
        {
            CompaniesName = companies.CompaniesName;
            CEO = companies.CEO;
            CNPJ = companies.CNPJ;
        }
    }
}
