using System;
using System.Threading.Tasks;
using MeuVelho.Domains;
using Microsoft.AspNetCore.Identity;

namespace MeuVelho.Application.Services.Identity
{
    public interface IIdentityService
    {
        public Task<IdentityResult> Create(UserDomain user);
        public Task ChangePassword(Guid idUser, string key, string password);
        public Task<SignInResult> Login(string userName, string password);
        public Task LogOut();
    }
}