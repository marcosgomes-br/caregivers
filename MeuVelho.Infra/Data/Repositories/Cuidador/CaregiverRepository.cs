using MeuVelho.Domains;
using MeuVelho.Infra.Data.Contexts;
using MeuVelho.Domains.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace MeuVelho.Infra.Data.Repositories
{
    public class CaregiverRepository : ICaregiverRepository
    {
        private readonly MeuVelhoContext contexto = new MeuVelhoContext();

        public void Desativar(Guid id)
        {
            var cuidador = contexto.Caregivers.AsTracking().Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (cuidador == null)
                throw new ValidationException("Falha ao desativar colaborador, cadastro inexistente.");
            cuidador.Disable();
            contexto.SaveChangesAsync();
        }

        public async Task<List<CaregiverDomain>> Get()
        {
            return await contexto.Caregivers.Include(x => x.Cities).OrderBy(o => o.FullName).ToListAsync();
        }

        public async Task<CaregiverDomain> Get(Guid id)
        {
            return await contexto.Caregivers.Where(x => x.Id.Equals(id))
                                            .Include(x => x.Cities)
                                            .FirstOrDefaultAsync();
        }

        public async Task<CaregiverDomain> Salvar(CaregiverDomain caregiver)
        {
            var existeNoBanco = contexto.Caregivers.Any(x => x.Id == caregiver.Id);
            if (existeNoBanco)
                contexto.Update(caregiver);
            else
                contexto.Caregivers.Add(caregiver);
            await contexto.SaveChangesAsync();
            return caregiver;
        }
    }
}
