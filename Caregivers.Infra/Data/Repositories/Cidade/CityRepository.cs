using Caregivers.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caregivers.Domains;

namespace Caregivers.Infra.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly CaregiversContext _context;

        public CityRepository(CaregiversContext context)
        {
            _context = context;
        }
        public async Task<List<City>> Get()
        {
            return await _context.Cities.OrderBy(x => x.Name)
                                    .Include(x => x.State)
                                    .ToListAsync();
        }
    }
}
