using MeuVelho.Infra.Data.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MeuVelho.Infra.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly MeuVelhoContext _db = new MeuVelhoContext();
        public async Task Salvar(Guid idCuidador)
        {
            _db.Contatos.Add(new Domains.ContatoDomain(idCuidador));
            await _db.SaveChangesAsync();
        }

        public int Totalizar()
        {
            return _db.Contatos.Count();
        }
    }
}
