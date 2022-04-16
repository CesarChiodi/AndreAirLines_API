using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class Classe
    {
        [JsonProperty("IdClasse")]
        [Key]
        public int IdClasse { get; set; }
        [JsonProperty("Valor")]
        public double Valor { get; set; }
        [JsonProperty("Descricao")]
        public string Descricao { get; set; }
    }
}
