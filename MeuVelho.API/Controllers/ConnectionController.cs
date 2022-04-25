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
        private readonly IContatoService contatoService;
        public ConnectionController(IContatoService _contatoService)
        {
            contatoService = _contatoService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(contatoDTO contato)
        {
            await contatoService.Salvar(contato.IdCuidador);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(contatoService.Totalizar());
        }

        public class contatoDTO
        {
            public Guid IdCuidador { get; set; }
            public string TextoAleatorio { get; set; }
        }
    }
}
