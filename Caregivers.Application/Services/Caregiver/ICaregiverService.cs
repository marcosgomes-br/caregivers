using Caregivers.Domains;
using Caregivers.Application.DTOs;
using System.Threading.Tasks;
using System;
using Caregivers.Infra.Data.Repositories;
using System.Collections.Generic;

namespace Caregivers.Application.Services
{
    public interface ICaregiverService
    {
        public Task<Guid> Save(CaregiverDto caregiver);
        public void Disable(Guid id);
        public Task<CaregiverDto> Get(Guid id);
        public Task<List<CaregiverDto>> Get();
    }
}
