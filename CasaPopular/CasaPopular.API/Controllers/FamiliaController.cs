using CasaPopular.API.Models;
using CasaPopular.Domain.Interfaces.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CasaPopular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaApplication familiaApplication;
        private readonly IPontuacaoApplication pontuacaoApplication;

        public FamiliaController(IFamiliaApplication familiaApplication, IPontuacaoApplication pontuacaoApplication)
        {
            this.familiaApplication = familiaApplication;
            this.pontuacaoApplication = pontuacaoApplication;
        }

        [HttpGet]
        [Route("ObterFamilias")]
        public async Task<IActionResult> ObterFamilias()
        {
            var listaFamilias = FamiliaModel.EntityToModel(await familiaApplication.GetAllAsync());
            return Ok(listaFamilias);
        }

        [HttpGet]
        [Route("ObterResultado")]
        public async Task<IActionResult> ObterResultado()
        {
            var listaFamilias = FamiliaResultadoModel.EntityToModel(await familiaApplication.GetAllAsync(), pontuacaoApplication);
            return Ok(listaFamilias);
        }

        [HttpPost]
        [Route("CadastrarFamilia")]
        public async Task<IActionResult> CadastrarFamilia(FamiliaModel model)
        {
            try
            {
                familiaApplication.Add(FamiliaModel.ModelToEntity(model));
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }


    }
}
