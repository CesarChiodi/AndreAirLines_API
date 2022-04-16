using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class Root
    {
        public string DataCadastro { get; set; }
        public Voo Voo { get; set; }
    }
    public class Voo
    {

        [JsonProperty("IdVoo")]
        [Key]
        public int IdVoo { get; set; }

        [JsonProperty("HorarioEmbarque")]
        public DateTime HorarioEmbarque { get; set; }

        [JsonProperty("HorarioDesembarque")]
        public DateTime HorarioDesembarque { get; set; }

        [JsonProperty("Destino")]
        public virtual Aeroporto Destino { get; set; }

        [JsonProperty("Origem")]
        //[ForeignKey("OrigemSigla")]
        //public string OrigemSigla { get; set; }
        public virtual Aeroporto Origem { get; set; }

        [JsonProperty("Aeronave")]
        public virtual Aeronave Aeronave { get; set; }
        //[JsonProperty("Passageiro")]
        //public virtual Passageiro Passageiro { get; set; }
    }
}
