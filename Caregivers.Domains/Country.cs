using System;
using System.Collections.Generic;

namespace Caregivers.Domains
{
    public class Country
    {
        public Country(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<State> States { get; private set; } = new List<State>();
    }
}