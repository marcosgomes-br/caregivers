using System;
using System.Collections.Generic;

namespace MeuVelho.Domains
{
    public class StateDomain
    {
        public StateDomain(Guid id, string nome, Guid idPais)
        {
            Id = id;
            Nome = nome;
            IdPais = idPais;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Guid IdPais { get; private set; }
        public virtual PaisDomain Pais { get; private set; }
        public ICollection<CityDomain> Cidades { get; private set; }
    }
}
