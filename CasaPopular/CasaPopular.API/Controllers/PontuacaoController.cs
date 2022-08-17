using CasaPopular.API.Models;
using CasaPopular.Domain.Interfaces.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CasaPopular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontuacaoController : ControllerBase
    {
        private readonly IPontuacaoApplication pontuacaoApplication;
        public PontuacaoController(IPontuacaoApplication pontuacaoApplication)
        {
            this.pontuacaoApplication = pontuacaoApplication;
        }

        [HttpGet]
        [Route("ObterPontuacao")]
        public async Task<IActionResult> ObterPontuacao()
        {
            var listaFamilias = PontuacaoModel.EntityToModel(await pontuacaoApplication.GetAllAsync());
            return Ok(listaFamilias);
        }

        [HttpPost]
        [Route("CadastrarPontuacao")]
        public async Task<IActionResult> CadastrarPontuacao(PontuacaoModel model)
        {
            try
            {
                pontuacaoApplication.Add(PontuacaoModel.ModelToEntity(model));
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }        
    }
}
