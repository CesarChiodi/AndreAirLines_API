using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class Passageiro
    {
        [JsonProperty("Cpf")]
        [Key]
        public string Cpf { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }
        [JsonProperty("Telefone")]
        public string Telefone { get; set; }
        [JsonProperty("DataNasc")]
        public DateTime DataNasc { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Endereco")]
        //[ForeignKey("IdEndereco")]
        //public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
