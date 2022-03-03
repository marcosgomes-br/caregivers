using MeuVelho.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public interface ICidadeService
    {
        public Task<List<CidadeResponse>> Listar();
    }
}
