using System;
using System.Collections.Generic;

namespace MeuVelho.Domains
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
        public virtual ICollection<StateDomain> States { get; private set; }
    }
}
