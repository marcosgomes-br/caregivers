using System;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public interface IContatoService
    {
        public Task Salvar(Guid idCuidador);
        public int Totalizar();
    }
}
