using System;
using System.Threading.Tasks;
using MeuVelho.Application.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuVelho.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(string email, string password, string phoneNumber)
        {
            return Ok(await _identityService.Create(email, password, phoneNumber));
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(Guid idUser, string key, string password)
        {
            await _identityService.ChangePassword(idUser, key, password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            return Ok(await _identityService.Login(userName, password));
        }

        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> LogOut()
        {
            await _identityService.LogOut();
            return Ok();
        }
    }
}