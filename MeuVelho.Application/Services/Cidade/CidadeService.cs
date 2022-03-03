using MeuVelho.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository cidadeRepository;
        public CidadeService(ICidadeRepository _cidadeRepository)
        {
            cidadeRepository = _cidadeRepository;
        }
        public async Task<List<CidadeResponse>> Listar()
        {
            return await cidadeRepository.Listar();
        }
    }
}
