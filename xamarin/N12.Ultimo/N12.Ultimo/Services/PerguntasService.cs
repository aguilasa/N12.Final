using N12.Ultimo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace N12.Ultimo.Services
{
    public class PerguntasService
    {
        private HttpClient _client = new HttpClient();

        public async Task<List<Pergunta>> GetPerguntas()
        {
            string url = "http://www.aguilasa.com/servicos/server/";
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
            string url = "http://www.aguilasa.com/servicos/server/resultados/";
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

        public async Task<bool> PostResponder(Pergunta pergunta, Resposta resposta)
        {
            string data = "{\"pergunta\": " + pergunta.Id + ", \"resposta\": " + resposta.Id + " }";
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            string url = "http://www.aguilasa.com/servicos/server/";

            var response = await _client.PostAsync(url, content);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                await response.Content.ReadAsStringAsync();
                return true;
            }
        }
    }
}
