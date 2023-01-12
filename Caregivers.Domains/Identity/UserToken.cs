using System;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Domains
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public User User { get; } = new User();
    }
}