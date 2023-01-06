using System;

namespace Caregivers.Domains
{
    public class ConnectionDomain
    {
        public ConnectionDomain(Guid idCaregiver)
        {
            Id = new Guid();
            Date = DateTime.Now;
            IdCaregiver = idCaregiver;
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public Guid IdCaregiver { get; private set; }
        public CaregiverDomain Caregiver { get; private set; }
    }
}
