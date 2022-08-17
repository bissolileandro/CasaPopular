using CasaPopular.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Domain.Interfaces.Applications
{
    public interface IPontuacaoApplication : IApplicationBase<Pontuacao>
    {
        int ObterResultadoDePontuacao(int familiaId);
    }
}
