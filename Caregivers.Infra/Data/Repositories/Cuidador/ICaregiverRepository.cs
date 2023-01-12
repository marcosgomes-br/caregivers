using Caregivers.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caregivers.Infra.Data.Repositories
{
    public interface ICaregiverRepository
    {
        public Task<Caregiver> Save(Caregiver caregiver);
        public Task<List<Caregiver>> Get();
        public Task<Caregiver> Get(Guid id);
        public void Disable(Guid id);
    }
}
