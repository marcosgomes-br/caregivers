using MeuVelho.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuVelho.Infra.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly MeuVelhoContext _db = new MeuVelhoContext();
        public async Task<List<CidadeResponse>> Listar()
        {
            return await _db.Cidades.Select(x => new CidadeResponse
                                    {
                                        Id = x.Id,
                                        Nome = x.Nome + " - " + x.Estado.Nome
                                    })
                                    .OrderBy(x => x.Nome)
                                    .ToListAsync();
        }
    }
}
