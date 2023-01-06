using Caregivers.Application.DTOs;
using Caregivers.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Caregivers.API.Controllers
{
    [Route("api/caregiver")]
    [ApiController]
    [AllowAnonymous]
    public class CaregiverController : ControllerBase
    {
        private readonly ICaregiverService _caregiverService;
        public CaregiverController(ICaregiverService caregiverService)
        {
            _caregiverService = caregiverService;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
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
        [Authorize(AuthenticationSchemes = "Bearer")]
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
