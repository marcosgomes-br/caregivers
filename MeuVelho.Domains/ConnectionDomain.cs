using System;

namespace MeuVelho.Domains
{
    public class ConnectionDomain
    {
        public ConnectionDomain(Guid idCuidador)
        {
            Id = new Guid();
            Data = DateTime.Now;
            IdCuidador = idCuidador;
        }

        public Guid Id { get; private set; }
        public DateTime Data { get; private set; }
        public Guid IdCuidador { get; private set; }
        public virtual CaregiverDomain Caregiver { get; private set; }
    }
}
