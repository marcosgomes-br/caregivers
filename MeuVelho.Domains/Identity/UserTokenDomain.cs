using System;
using Microsoft.AspNetCore.Identity;

namespace MeuVelho.Domains
{
    public class UserTokenDomain : IdentityUserToken<Guid>
    {
        public UserDomain User { get; } = new UserDomain();
    }
}