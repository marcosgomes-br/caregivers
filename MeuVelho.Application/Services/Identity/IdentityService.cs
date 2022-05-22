using System;
using System.Threading.Tasks;
using MeuVelho.Domains;
using Microsoft.AspNetCore.Identity;

namespace MeuVelho.Application.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<UserDomain> _userManager;
        private readonly SignInManager<UserDomain> _signInManager;
        public IdentityService(UserManager<UserDomain> userManager, SignInManager<UserDomain> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Create(UserDomain user)
        {
            return await _userManager.CreateAsync(user);
        }

        public async Task ChangePassword(Guid idUser, string key, string password)
        {
            var user = await _userManager.FindByIdAsync(idUser.ToString()); 
            await _userManager.ChangePasswordAsync(user, key, password);
        }

        public async Task<SignInResult> Login(string userName, string password)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, false, false);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}