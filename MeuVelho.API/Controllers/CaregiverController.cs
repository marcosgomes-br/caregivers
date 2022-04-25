using MeuVelho.Application.DTOs;
using MeuVelho.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MeuVelho.API.Controllers
{
    [Route("api/caregiver")]
    [ApiController]
    public class CaregiverController : ControllerBase
    {
        private readonly ICaregiverService _caregiverService;
        public CaregiverController(ICaregiverService caregiverService)
        {
            _caregiverService = caregiverService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CaregiverDto caregiver)
        {
            return Created("", await _caregiverService.Save(caregiver));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _caregiverService.Get());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _caregiverService.Get(id));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _caregiverService.Disable(id);
            return Ok();
        }
    }
}
