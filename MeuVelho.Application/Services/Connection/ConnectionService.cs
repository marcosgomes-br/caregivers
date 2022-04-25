using MeuVelho.Infra.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectionRepository _connectionRepository;
        public ConnectionService(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }
        public async Task Save(Guid idCaregiver)
        {
            await _connectionRepository.Save(idCaregiver);
        }

        public int Count()
        {
            return _connectionRepository.Count();
        }
    }
}
