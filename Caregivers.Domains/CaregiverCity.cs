using System;

namespace Caregivers.Domains
{
    public class CaregiverCity
    {
        public CaregiverCity(Guid idCaregiver, Guid idCity)
        {
            IdCaregiver = idCaregiver;
            IdCity = idCity;
        }

        public Guid IdCaregiver { get; private set; }
        public Guid IdCity { get; private set; }
        public Caregiver? Caregiver { get; set; }
        public City? City { get; set; }
    }
}
