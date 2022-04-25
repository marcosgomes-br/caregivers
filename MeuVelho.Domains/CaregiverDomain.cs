using MeuVelho.Domains.Validations;
using System;
using System.Collections.Generic;
using static MeuVelho.Domains.Enums.MeuVelhoEnums;

namespace MeuVelho.Domains
{
    public class CaregiverDomain
    {
        public CaregiverDomain(Guid id, string fullName, Gender gender, 
            string photo, string biography, string whatsapp)
        {
            Id = id;
            FullName = fullName;
            Gender = gender;
            Photo = photo;
            Biography = biography;
            Whatsapp = whatsapp;

            var validationResult = new CaregiverValidation().Validate(this);
            if (!validationResult.IsValid)
                throw new ApplicationException(validationResult.ToString("; "));
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public Gender Gender { get; private set; }
        public string Photo { get; private set; }
        public string Biography { get; private set; }
        public string Whatsapp { get; private set; }
        public bool Active { get; private set; } = true;
        public DateTime RegisterIn { get; private set; } = DateTime.Now;
        public DateTime? DisabledIn { get; private set; }
        public ICollection<ConnectionDomain> Connections { get; set; }
        public ICollection<CityDomain> Cities { get; set; }
        public ICollection<CaregiverCityDomain> CaregiversCities { get; set; }

        public void Disable()
        {
            Active = false;
            DisabledIn = DateTime.Now;
        }
    }
}
