using System;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Domains
{
    public class UserRoleDomain : IdentityUserRole<Guid>
    {
        public User User { get; } = new User();
        public Role Role { get; } = new Role();
    }
}