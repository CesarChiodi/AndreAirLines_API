using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class PrecoBase
    {
        [JsonProperty("IdPrecoBase")]
        [Key]
        public int IdPrecoBase { get; set; }
        [JsonProperty("Valor")]
        public double Valor { get; set; }
        [JsonProperty("PromocaoPorcentagem")]
        public double PromocaoPorcentagem { get; set; }
        [JsonProperty("DataInclusao")]
        public DateTime DataInclusao { get; set; }
        [JsonProperty("Destino")]
        public virtual Aeroporto Destino { get; set; }
        [JsonProperty("Origem")]
        public virtual Aeroporto Origem { get; set; }
    }
}
