using Caregivers.Infra.Data.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Caregivers.Infra.Data.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly MeuVelhoContext _context;

        public ConnectionRepository(MeuVelhoContext context)
        {
            _context = context;
        }
        public async Task Save(Guid idCaregiver)
        {
            _context.Connections.Add(new Domains.ConnectionDomain(idCaregiver));
            await _context.SaveChangesAsync();
        }

        public int Count()
        {
            return _context.Connections.Count();
        }
    }
}
