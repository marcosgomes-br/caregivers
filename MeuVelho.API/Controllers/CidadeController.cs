using MeuVelho.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeuVelho.API.Controllers
{
    [Route("api/cidade")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService cidadeService;
        public CidadeController(ICidadeService _cidadeService)
        {
            cidadeService = _cidadeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await cidadeService.Listar());
        }
    }
}
