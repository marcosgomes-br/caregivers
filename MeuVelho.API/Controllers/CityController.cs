using MeuVelho.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeuVelho.API.Controllers
{
    [Route("api/cidade")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICidadeService cityService;
        public CityController(ICidadeService cityService)
        {
            cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await cityService.Get());
        }
    }
}
