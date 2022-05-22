using System;
using Microsoft.AspNetCore.Identity;

namespace MeuVelho.Domains
{
    public class UserRoleDomain : IdentityUserRole<Guid>
    {
        public UserDomain User { get; } = new UserDomain();
        public RoleDomain Role { get; } = new RoleDomain();
    }
}