using System;

namespace MeuVelho.Domains
{
    public class CaregiverCityDomain
    {
        public CaregiverCityDomain(Guid idCuidador, Guid idCidade)
        {
            IdCuidador = idCuidador;
            IdCidade = idCidade;
        }

        public Guid IdCuidador { get; private set; }
        public Guid IdCidade { get; private set; }
        public virtual CuidadorDomain Cuidador { get; set; }
        public virtual CidadeDomain Cidade { get; set; }
    }
}
