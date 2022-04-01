using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class Aeronave
    {
        [JsonProperty("IdAeronave")]
        [Key]
        public string IdAeronave { get; set; }
        [JsonProperty("NomeAeronave")]
        public string NomeAeronave { get; set; }
        [JsonProperty("CapacidadeAeronave")]
        public int CapacidadeAeronave { get; set; }
    }
}
