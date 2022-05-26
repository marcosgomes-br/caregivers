using System;
using System.Linq;
using System.Threading.Tasks;
using MeuVelho.Application.DTOs;
using MeuVelho.Application.Helpers;
using MeuVelho.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace MeuVelho.Application.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<UserDomain> _userManager;
        private readonly SignInManager<UserDomain> _signInManager;
        private readonly IConfiguration _configuration;
        public IdentityService(UserManager<UserDomain> userManager, SignInManager<UserDomain> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> Create(string email, string password, string phoneNumber)
        {
            var user = new UserDomain
            {
                Email = email,
                UserName = email.Split('@').First(),
                PhoneNumber = phoneNumber,
                PhoneNumberConfirmed = false,
                EmailConfirmed = false
            };
            return await _userManager.CreateAsync(user, password);
        }

        public async Task ChangePassword(Guid idUser, string key, string password)
        {
            var user = await _userManager.FindByIdAsync(idUser.ToString()); 
            await _userManager.ChangePasswordAsync(user, key, password);
        }

        public async Task<TokenDto> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, true);
            if (!result.Succeeded) throw new Exception("Invalid User or Password");
            
            var user = await _userManager.FindByNameAsync(userName);
            return Token.Generate(user, _configuration);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}