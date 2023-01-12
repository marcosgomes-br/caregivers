using System;

namespace Caregivers.Domains
{
    public class Connection
    {
        public Connection(Guid idCaregiver)
        {
            Id = new Guid();
            Date = DateTime.Now;
            IdCaregiver = idCaregiver;
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public Guid IdCaregiver { get; private set; }
        public Caregiver? Caregiver { get; set; }
    }
}
