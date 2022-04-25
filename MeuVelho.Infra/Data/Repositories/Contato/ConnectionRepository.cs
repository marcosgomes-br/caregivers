using MeuVelho.Infra.Data.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeuVelho.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly MeuVelhoContext _db = new MeuVelhoContext();
        public async Task Save(Guid idCaregiver)
        {
            _db.Connections.Add(new Domains.ConnectionDomain(idCaregiver));
            await _db.SaveChangesAsync();
        }

        public int Count()
        {
            return _db.Connections.Count();
        }
    }
}
