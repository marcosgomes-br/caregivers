using System;
using System.Collections.Generic;

namespace Caregivers.Domains
{
    public class State
    {
        public State(Guid id, string name, Guid idCountry)
        {
            Id = id;
            Name = name;
            IdCountry = idCountry;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid IdCountry { get; private set; }
        public Country? Country { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
