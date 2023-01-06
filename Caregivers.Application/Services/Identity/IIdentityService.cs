using System;
using System.Threading.Tasks;
using Caregivers.Application.DTOs;
using Caregivers.Domains;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Application.Services.Identity
{
    public interface IIdentityService
    {
        public Task<IdentityResult> Create(string email, string password, string phoneNumber);
        public Task ChangePassword(Guid idUser, string key, string password);
        public Task<TokenDto> Login(string userName, string password);
        public Task LogOut();
    }
}