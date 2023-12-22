using Caregivers.Infra.Data.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Caregivers.Infra.Data.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly CaregiversContext _context;

        public ConnectionRepository(CaregiversContext context)
        {
            _context = context;
        }
        public async Task Save(Guid idCaregiver)
        {
            _context.Connections.Add(new Domains.Connection(idCaregiver));
            await _context.SaveChangesAsync();
        }

        public int Count()
        {
            return _context.Connections.Count();
        }
    }
}
