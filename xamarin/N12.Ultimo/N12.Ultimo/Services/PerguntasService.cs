using N12.Ultimo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace N12.Ultimo.Services
{
    public class PerguntasService
    {
        private HttpClient _client = new HttpClient();

        public async Task<List<Pergunta>> GetPerguntas()
        {
            string url = "http://localhost:8000/perguntas";
            List<Pergunta> perguntas = null;

            var response = await _client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                perguntas = new List<Pergunta>();
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<List<Pergunta>>(content);
                perguntas = new List<Pergunta>(dados);
            }
            return perguntas;
        }

        public async Task<List<Pergunta>> GetResultados()
        {
            string url = "http://localhost:8000/perguntas/resultados";
            List<Pergunta> perguntas = null;

            var response = await _client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                perguntas = new List<Pergunta>();
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<List<Pergunta>>(content);
                perguntas = new List<Pergunta>(dados);
            }
            return perguntas;
        }
    }
}
