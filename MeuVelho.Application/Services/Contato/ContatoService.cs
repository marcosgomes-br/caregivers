using MeuVelho.Infra.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository contatoRepository;
        public ContatoService(IContatoRepository _contatoRepository)
        {
            contatoRepository = _contatoRepository;
        }
        public async Task Salvar(Guid idCuidador)
        {
            await contatoRepository.Salvar(idCuidador);
        }

        public int Totalizar()
        {
            return contatoRepository.Totalizar();
        }
    }
}
