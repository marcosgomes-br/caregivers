using MeuVelho.Domains.Validations;
using System;
using System.Collections.Generic;
using static MeuVelho.Domains.Enums.MeuVelhoEnums;

namespace MeuVelho.Domains
{
    public class CaregiverDomain
    {
        public CaregiverDomain(Guid id, string nome, Gender gender, string foto, string biografia, string whatsapp)
        {
            Id = id;
            Nome = nome;
            Gender = gender;
            Foto = foto;
            Biografia = biografia;
            Whatsapp = whatsapp;
            Ativo = true;

            var entidade = new CaregiverValidation().Validate(this);
            if (!entidade.IsValid)
                throw new ApplicationException(entidade.ToString("; "));
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Gender Gender { get; set; }
        public string Foto { get; private set; }
        public string Biografia { get; private set; }
        public string Whatsapp { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataDesativacao { get; private set; }
        public virtual ICollection<ContatoDomain> Contatos { get; set; }
        public virtual ICollection<CidadeDomain> Cidades { get; set; }
        public virtual ICollection<CaregiverCityDomain> CaregiversCities { get; set; }

        public void Desativar()
        {
            Ativo = false;
            DataDesativacao = DateTime.Now;
        }
    }
}
