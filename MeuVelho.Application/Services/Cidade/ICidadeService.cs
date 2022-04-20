using MeuVelho.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVelho.Application.DTOs;
using MeuVelho.Domains;

namespace MeuVelho.Application.Services
{
    public interface ICidadeService
    {
        public Task<List<CidadeDTO>> Listar();
    }
}
