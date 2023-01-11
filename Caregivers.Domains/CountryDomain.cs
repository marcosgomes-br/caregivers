using System;
using System.Collections.Generic;

namespace Caregivers.Domains
{
    public class CountryDomain
    {
        public CountryDomain(){}
        public CountryDomain(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<StateDomain> States { get; private set; } = new List<StateDomain>();
    }
}
