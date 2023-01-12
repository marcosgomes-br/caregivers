using System;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Domains
{
    public class Login : IdentityUserLogin<Guid>
    {
        public User User { get; } = new User();
    }
}