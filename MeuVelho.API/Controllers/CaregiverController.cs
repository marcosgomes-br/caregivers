using MeuVelho.Application.DTOs;
using MeuVelho.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MeuVelho.API.Controllers
{
    [Route("api/cuidador")]
    [ApiController]
    public class CuidadorController : ControllerBase
    {
        private readonly ICuidadorService cuidadorService;
        public CuidadorController(ICuidadorService _cuidadorservice)
        {
            cuidadorService = _cuidadorservice;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CuidadorDTO cuidador)
        {
            return Created("", await cuidadorService.Salvar(cuidador));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await cuidadorService.Listar());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await cuidadorService.Pegar(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            cuidadorService.Desativar(id);
            return Ok();
        }
    }
}
