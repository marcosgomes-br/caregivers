using System;

namespace MeuVelho.Domains
{
    public class ContatoDomain
    {
        public ContatoDomain(Guid idCuidador)
        {
            Id = new Guid();
            Data = DateTime.Now;
            IdCuidador = idCuidador;
        }

        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public Guid IdCuidador { get; private set; }
        public virtual CuidadorDomain Cuidador { get; private set; }
    }
}
