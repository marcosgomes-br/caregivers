using MeuVelho.Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuVelho.Infra.Data.Repositories
{
    public interface ICaregiverRepository
    {
        public Task<CaregiverDomain> Salvar(CaregiverDomain caregiver);
        public Task<List<CaregiverDomain>> Get();
        public Task<CaregiverDomain> Get(Guid id);
        public void Desativar(Guid id);
    }
}
