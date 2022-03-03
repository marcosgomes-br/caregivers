using System;
using System.Collections.Generic;

namespace MeuVelho.Domains
{
    public class PaisDomain
    {
        public PaisDomain(){}
        public PaisDomain(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public virtual ICollection<EstadoDomain> Estados { get; private set; }
    }
}
