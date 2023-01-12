using System;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Domains
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public Role Role { get; } = new Role();
    }
}