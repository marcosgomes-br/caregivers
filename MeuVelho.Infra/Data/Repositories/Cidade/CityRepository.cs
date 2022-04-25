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
        public async Task<List<CidadeDomain>> Listar()
        {
            return await _db.Cidades.OrderBy(x => x.Nome)
                                    .Include(x => x.Estado)
                                    .ToListAsync();
        }
    }
}
