using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Domain.Entities
{
    public  class Pontuacao : EntidadeBase
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Pontos { get; set; }
    }
}
