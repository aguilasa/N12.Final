using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N12.Ultimo.Models
{
    public class Resultado
    {
        public string Texto { get; set; }
        public int Total { get; set; }
    }

    public class Resposta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
    }

    public class Pergunta
    {
        public int Id { get; set; }
        public string Texto { get; set; }

        private List<Resposta> respostas = new List<Resposta>();
        public List<Resposta> Respostas
        {
            get
            {
                return respostas;
            }
        }

        private List<Resultado> resultados = new List<Resultado>();
        public List<Resultado> Resultados
        {
            get
            {
                return resultados;
            }
        }
    }

}
