using System;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Domains
{
    public class LoginDomain : IdentityUserLogin<Guid>
    {
        public UserDomain User { get; } = new UserDomain();
    }
}