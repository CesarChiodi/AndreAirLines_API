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
        [JsonProperty("IdAeronave")]
        public string IdAeronave { get; set; }
        [JsonProperty("EnderecoAeroporto")]
        //[ForeignKey("IdEndereco")]
        //public int IdEndereco { get; set; }
        public virtual Endereco EnderecoAeroporto { get; set; }
    }
}
