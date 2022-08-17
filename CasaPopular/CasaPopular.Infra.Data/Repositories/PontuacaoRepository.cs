using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Repositories;
using CasaPopular.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Infra.Data.Repositories
{
    public class PontuacaoRepository : RepositoryBase<Pontuacao>, IPontuacaoRepository
    {
        public PontuacaoRepository(CasaPopularContext context)
            : base(context)
        {

        }
    }
}
