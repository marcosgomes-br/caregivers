using System;
using Microsoft.AspNetCore.Identity;

namespace MeuVelho.Domains
{
    public class LoginDomain : IdentityUserLogin<Guid>
    {
        public UserDomain User { get; } = new UserDomain();
    }
}