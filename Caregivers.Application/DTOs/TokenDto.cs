using System;

namespace Caregivers.Application.DTOs
{
    public class TokenDto
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}