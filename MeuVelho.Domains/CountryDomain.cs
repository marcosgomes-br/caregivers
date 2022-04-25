using System;
using System.Collections.Generic;

namespace MeuVelho.Domains
{
    public class CountryDomain
    {
        public CountryDomain(){}
        public CountryDomain(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public virtual ICollection<StateDomain> Estados { get; private set; }
    }
}
