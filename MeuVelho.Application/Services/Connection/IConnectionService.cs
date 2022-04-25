using System;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public interface IConnectionService
    {
        public Task Save(Guid idCuidador);
        public int Count();
    }
}
