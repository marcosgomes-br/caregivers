using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVelho.Domains;

namespace MeuVelho.Infra.Data.Repositories
{
    public interface ICityRepository
    {
        public Task<List<CidadeDomain>> Listar();
    }
}
