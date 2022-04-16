using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class Aeroporto
    {
        [JsonProperty("Sigla")]
        [Key]
        public string Sigla { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }
        [JsonProperty("EnderecoAeroporto")]
        public virtual Endereco EnderecoAeroporto { get; set; }
    }
}
