using Caregivers.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caregivers.Infra.Data.Repositories
{
    public interface ICaregiverRepository
    {
        public Task<CaregiverDomain> Save(CaregiverDomain caregiver);
        public Task<List<CaregiverDomain>> Get();
        public Task<CaregiverDomain> Get(Guid id);
        public void Disable(Guid id);
    }
}
