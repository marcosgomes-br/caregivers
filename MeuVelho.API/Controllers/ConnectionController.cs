using MeuVelho.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MeuVelho.API.Controllers
{
    [Route("api/connection")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly IConnectionService _connectionService;
        public ConnectionController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Guid idCaregiver)
        {
            await _connectionService.Save(idCaregiver);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_connectionService.Count());
        }
    }
}
