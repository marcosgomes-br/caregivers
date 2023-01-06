using System;

namespace Caregivers.Domains
{
    public class CaregiverCityDomain
    {
        public CaregiverCityDomain(Guid idCaregiver, Guid idCity)
        {
            IdCaregiver = idCaregiver;
            IdCity = idCity;
        }

        public Guid IdCaregiver { get; private set; }
        public Guid IdCity { get; private set; }
        public CaregiverDomain Caregiver { get; set; }
        public CityDomain City { get; set; }
    }
}
