using MeuVelho.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVelho.Application.DTOs;
using AutoMapper;

namespace MeuVelho.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository cidadeRepository;
        private readonly IMapper mapper;
        public CidadeService(ICidadeRepository _cidadeRepository, IMapper _mapper)
        {
            cidadeRepository = _cidadeRepository;
            mapper = _mapper;
        }
        public async Task<List<CidadeDTO>> Listar()
        {
            return mapper.Map<List<CidadeDTO>>(await cidadeRepository.Listar());
        }
    }
}
