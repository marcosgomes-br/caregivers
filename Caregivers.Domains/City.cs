
using System;
using System.Collections.Generic;

namespace Caregivers.Domains
{
    public class City
    {
        public City(Guid id, string name, Guid idState)
        {
            Id = id;
            Name = name;
            IdState = idState;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid IdState { get; private set; }
        public State? State { get; set; }
        public ICollection<Caregiver> Caregivers { get; set; } = new List<Caregiver>();
        public ICollection<CaregiverCity> CaregiversCities { get; set; } = new List<CaregiverCity>(); 
    }
}
