using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Repositories;
using CasaPopular.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Service.Services
{
    public class PontuacaoService : ServiceBase<Pontuacao>, IPontuacaoService
    {
        private IPontuacaoRepository pontuacaoRepository;
        public PontuacaoService(IPontuacaoRepository pontuacaoRepository)
            :base(pontuacaoRepository)
        {
            this.pontuacaoRepository = pontuacaoRepository;
        }
    }
}
