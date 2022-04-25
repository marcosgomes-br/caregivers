using MeuVelho.Domains;
using MeuVelho.Application.DTOs;
using System.Threading.Tasks;
using System;
using MeuVelho.Infra.Data.Repositories;
using System.Collections.Generic;

namespace MeuVelho.Application.Services
{
    public interface ICaregiverService
    {
        public Task<Guid> Save(CaregiverDto caregiver);
        public void Disable(Guid id);
        public Task<CaregiverDto> Get(Guid id);
        public Task<List<CaregiverDto>> Get();
    }
}
