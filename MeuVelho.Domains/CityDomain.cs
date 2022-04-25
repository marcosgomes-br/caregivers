
using System;
using System.Collections.Generic;

namespace MeuVelho.Domains
{
    public class CityDomain
    {
        public CityDomain(Guid id, string name, Guid idState)
        {
            Id = id;
            Name = name;
            IdState = idState;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid IdState { get; private set; }
        public StateDomain State { get; private set; }
        public ICollection<CaregiverDomain> Caregivers { get; set; }
        public ICollection<CaregiverCityDomain> CaregiversCities { get; set; }
    }
}
