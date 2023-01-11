#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using static Caregivers.Domains.Enums.CaregiversEnums;

namespace Caregivers.Application.DTOs
{
    public class CaregiverDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Photo { get; set; }
        public string Biography { get; set; }
        public string Whatsapp { get; set; }
        public List<CityDto> CitiesServed { get; set; }
    }
}
