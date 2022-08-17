using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Applications;
using CasaPopular.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Application.Applications
{
    public class PontuacaoApplication : ApplicationBase<Pontuacao>, IPontuacaoApplication
    {
        private IFamiliaService familiaService;
        private IPontuacaoService pontuacaoService;
        public PontuacaoApplication(IPontuacaoService pontuacaoService, IFamiliaService familiaService)
            : base(pontuacaoService)
        {
            this.familiaService = familiaService;
            this.pontuacaoService = pontuacaoService;
        }

        public int ObterResultadoDePontuacao(int familiaId)
        {
            var familia = familiaService.GetById(familiaId);
            return CalcularPontuacao(familia.Result);
            
        }

        private int CalcularPontuacao(Familia familia)
        {
            var listaPontuacao = pontuacaoService.GetAll();
            int notaTotal = 0;

            var pontuacaoRenda = listaPontuacao.Where(c => c.Descricao.Contains("Renda") && familia.RendaTotal <= c.Valor).FirstOrDefault();
            var pontuacaoDependentes = listaPontuacao.Where(c => c.Descricao.Contains("Dependente") && familia.DependentesMenores >= c.Valor);
            notaTotal += pontuacaoRenda != null ? pontuacaoRenda.Pontos : 0;
            notaTotal += pontuacaoDependentes != null ? Convert.ToInt32(pontuacaoDependentes.Max(c => c.Pontos)) : 0;

            return notaTotal;

        }
    }
}
