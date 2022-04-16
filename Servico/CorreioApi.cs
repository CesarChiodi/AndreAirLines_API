using System.Net.Http;
using System.Threading.Tasks;
using AndreAirLines_API.Model;
using Newtonsoft.Json;

namespace AndreAirLines_API.InsertCorreioApi
{
    public class CorreioApi
    {
        static readonly HttpClient client = new HttpClient();
        public static async Task<Endereco> ViacepJsonAsync(string cep)
        {

            try
            {
                var resposta = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                resposta.EnsureSuccessStatusCode();
                string responseBody = await resposta.Content.ReadAsStringAsync();
                var endereco = JsonConvert.DeserializeObject<Endereco>(responseBody);
                return endereco;
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
