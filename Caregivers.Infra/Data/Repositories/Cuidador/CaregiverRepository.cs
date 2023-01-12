using Caregivers.Domains;
using Caregivers.Infra.Data.Contexts;
using Caregivers.Domains.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Caregivers.Infra.Data.Repositories
{
    public class CaregiverRepository : ICaregiverRepository
    {
        private readonly MeuVelhoContext _context;

        public CaregiverRepository(MeuVelhoContext context)
        {
            _context = context;
        }

        public void Disable(Guid id)
        {
            var caregiver = _context.Caregivers.AsTracking().FirstOrDefault(x => x.Id.Equals(id));
            if (caregiver == null)
                throw new ValidationException("Failed to deactivate, non-existent registration.");
            caregiver.Disable();
            _context.SaveChangesAsync();
        }

        public async Task<List<Caregiver>> Get()
        {
            return await _context.Caregivers.Include(x => x.Cities).OrderBy(o => o.FullName).ToListAsync();
        }

        public async Task<Caregiver> Get(Guid id)
        {
            return await _context.Caregivers.Where(x => x.Id.Equals(id))
                                            .Include(x => x.Cities)
                                            .FirstOrDefaultAsync();
        }

        public async Task<Caregiver> Save(Caregiver caregiver)
        {
            var anyRegister = _context.Caregivers.Any(x => x.Id == caregiver.Id);
            if (anyRegister)
                _context.Update(caregiver);
            else
                _context.Caregivers.Add(caregiver);
            await _context.SaveChangesAsync();
            return caregiver;
        }
    }
}
