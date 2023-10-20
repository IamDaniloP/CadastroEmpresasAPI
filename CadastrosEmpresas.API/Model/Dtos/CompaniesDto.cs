using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CadastrosEmpresas.API.Model.Validations;

namespace CadastrosEmpresas.API.Model.Dtos
{
    public class CompaniesDto
    {
        [Required]
        [JsonPropertyName("companiesName")]
        public string CompaniesName { get; set; }

        [Required]
        [JsonPropertyName("creationDate")]
        public DateOnly CreationDate { get; set; }

        [Required]
        [JsonPropertyName("ceo")]
        public string CEO { get; set; }

        [Required]
        [CnpjValidation]
        [JsonPropertyName("cnpj")]
        public string CNPJ { get; set; }

        [Required]
        [JsonPropertyName("niche")]
        public string Niche { get; set; }

        public CompaniesDto() { }

        public CompaniesDto(string companiesName, string creationDate, string ceo, string cnpj, string niche)
        {
            CompaniesName = companiesName;
            CreationDate = DateOnly.Parse(creationDate);
            CEO = ceo;
            CNPJ = cnpj;
            Niche = niche;
        }
    }
}
