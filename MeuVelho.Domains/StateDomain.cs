using System;
using System.Collections.Generic;

namespace MeuVelho.Domains
{
    public class StateDomain
    {
        public StateDomain(Guid id, string name, Guid idCountry)
        {
            Id = id;
            Name = name;
            IdCountry = idCountry;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid IdCountry { get; private set; }
        public CountryDomain Country { get; private set; }
        public ICollection<CityDomain> Cities { get; private set; }
    }
}
