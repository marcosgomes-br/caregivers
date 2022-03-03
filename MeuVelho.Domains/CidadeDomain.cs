
using System;
using System.Collections.Generic;

namespace MeuVelho.Domains
{
    public class CidadeDomain
    {
        public CidadeDomain(Guid id, string nome, Guid idEstado)
        {
            Id = id;
            Nome = nome;
            IdEstado = idEstado;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Guid IdEstado { get; private set; }
        public virtual EstadoDomain Estado { get; private set; }
        public virtual ICollection<CuidadorDomain> Cuidadores { get; set; }
        public virtual ICollection<CuidadorCidadeDomain> CuidadoresCidade { get; set; }
    }
}
