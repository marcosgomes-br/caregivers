using MeuVelho.Infra.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IContatoRepository contatoRepository;
        public ConnectionService(IContatoRepository _contatoRepository)
        {
            contatoRepository = _contatoRepository;
        }
        public async Task Save(Guid idCuidador)
        {
            await contatoRepository.Salvar(idCuidador);
        }

        public int Count()
        {
            return contatoRepository.Totalizar();
        }
    }
}
