using MeuVelho.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuVelho.Domains;

namespace MeuVelho.Infra.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly MeuVelhoContext _db = new MeuVelhoContext();
        public async Task<List<CityDomain>> Get()
        {
            return await _db.Cities.OrderBy(x => x.Name)
                                    .Include(x => x.State)
                                    .ToListAsync();
        }
    }
}
