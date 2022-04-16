using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AndreAirLines_API.Model
{
    public class Passagem
    {
        [JsonProperty("IdPassagem")]
        [Key]
        public int IdPassagem { get; set; }
        [JsonProperty("DataCadastro")]
        public DateTime DataCadastro { get; set; }
        [JsonProperty("Voo")]
        public Voo Voo { get; set; }
        [JsonProperty("Passageiro")]
        public Passageiro Passageiro { get; set; }
        [JsonProperty("Valor")]
        public double ValorPassagem { get; set; }
        [JsonProperty("Classe")]
        public Classe Classe { get; set; }
        [JsonProperty("PrecoBase")]
        public PrecoBase PrecoBase { get; set; }
        //[JsonProperty("PromocaoPorcentagem")]
        //public PrecoBase PromocaoPorcentagem { get; set; }

        //public Passagem(Classe classe, PrecoBase precoBase, PrecoBase promocaoPorcentagem)
        //{
        //    Valor = (precoBase.Valor + classe.Valor) * promocaoPorcentagem.Valor;
        //    Classe = classe;
        //    PrecoBase = precoBase;
        //    PromocaoPorcentagem = promocaoPorcentagem;
        //}
    }
}
