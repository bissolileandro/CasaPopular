using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Domain.Entities
{
    public class Familia : EntidadeBase
    {
        public string NomeDaFamilia { get; set; }
        public double RendaTotal { get; set; }
        public int DependentesMaiores { get; set; }
        public int DependentesMenores { get; set; }

    }
}
