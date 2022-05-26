using MeuVelho.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MeuVelho.API.Controllers
{
    [Route("api/city")]
    [ApiController]
    [AllowAnonymous]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cityService.Get());
        }
    }
}
