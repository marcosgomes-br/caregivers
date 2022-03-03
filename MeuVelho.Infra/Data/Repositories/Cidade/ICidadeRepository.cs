using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuVelho.Infra.Data.Repositories
{
    public interface ICidadeRepository
    {
        public Task<List<CidadeResponse>> Listar();
    }
}
