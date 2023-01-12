using System;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Domains
{
    public class RoleClaimDomain : IdentityRoleClaim<Guid>
    {
        public RoleDomain Role { get; } = new RoleDomain();
    }
}