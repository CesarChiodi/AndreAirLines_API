using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class Endereco
    {
        [JsonProperty("IdEndereco")]
        [Key]
        public int IdEndereco { get; set; }
        [JsonProperty("Bairro")]
        public string Bairro { get; set; }
        [JsonProperty("Cidade")]
        public string Cidade { get; set; }
        [JsonProperty("Pais")]
        public string Pais { get; set; }
        [JsonProperty("Cep")]
        public string Cep { get; set; }
        [JsonProperty("Logradouro")]
        public string Logradouro { get; set; }
        [JsonProperty("Estado")]
        public string Estado { get; set; }
        [JsonProperty("Numero")]
        public int Numero { get; set; }
        [JsonProperty("Complemento")]
        public string Complemento { get; set; }

        public Endereco(int idEndereco, string bairro, string cidade, string pais, string cep, string logradouro, string estado, int numero, string complemento)
        {
            IdEndereco = idEndereco;
            Bairro = bairro;
            Cidade = cidade;
            Pais = pais;
            Cep = cep;
            Logradouro = logradouro;
            Estado = estado;
            Numero = numero;
            Complemento = complemento;
        }
    }
}
