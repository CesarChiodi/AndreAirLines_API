using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
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
        //[ForeignKey("DestinoSigla")]
        //public string DestinoSigla { get; set; }
        public virtual Aeroporto Destino { get; set; }
        [JsonProperty("Origem")]
        //[ForeignKey("OrigemSigla")]
        public string OrigemSigla { get; set; }
        public virtual Aeroporto Origem { get; set; }
        [JsonProperty("Aeronave")]
        //[ForeignKey("IdAeronave")]
        //public string IdAeronave { get; set; }
        public virtual Aeronave Aeronave { get; set; }
        [JsonProperty("Passageiro")]
        //[ForeignKey("Cpf")]
        //public string Cpf { get; set; }
        public virtual Passageiro Passageiro { get; set; }
    }
}
