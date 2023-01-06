using System;
using Microsoft.AspNetCore.Identity;

namespace Caregivers.Domains
{
    public class UserTokenDomain : IdentityUserToken<Guid>
    {
        public UserDomain User { get; } = new UserDomain();
    }
}