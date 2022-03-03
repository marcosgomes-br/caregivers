using MeuVelho.Domains.Validations;
using System;
using System.Collections.Generic;
using static MeuVelho.Domains.Enums.MeuVelhoEnums;

namespace MeuVelho.Domains
{
    public class CuidadorDomain
    {
        public CuidadorDomain(Guid id, string nome, Sexo sexo, string foto, string biografia, string whatsapp)
        {
            Id = id;
            Nome = nome;
            Sexo = sexo;
            Foto = foto;
            Biografia = biografia;
            Whatsapp = whatsapp;
            Ativo = true;

            var entidade = new CuidadorValidation().Validate(this);
            if (!entidade.IsValid)
                throw new ApplicationException(entidade.ToString("; "));
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Sexo Sexo { get; set; }
        public string Foto { get; private set; }
        public string Biografia { get; private set; }
        public string Whatsapp { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataDesativacao { get; private set; }
        public virtual ICollection<ContatoDomain> Contatos { get; set; }
        public virtual ICollection<CidadeDomain> Cidades { get; set; }
        public virtual ICollection<CuidadorCidadeDomain> CuidadoresCidade { get; set; }

        public void Desativar()
        {
            Ativo = false;
            DataDesativacao = DateTime.Now;
        }
    }
}
