using Caregivers.Domains.Validations;
using System;
using System.Collections.Generic;
using static Caregivers.Domains.Enums.CaregiversEnums;

namespace Caregivers.Domains
{
    public class Caregiver
    {
        public Caregiver(Guid id, string fullName, Gender gender, 
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
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
        public ICollection<City> Cities { get; set; } = new List<City>();
        public ICollection<CaregiverCity> CaregiversCities { get; set; } = new List<CaregiverCity>();

        public void Disable()
        {
            Active = false;
            DisabledIn = DateTime.Now;
        }
    }
}
