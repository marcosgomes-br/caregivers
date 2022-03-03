using System;
using System.Threading.Tasks;

namespace MeuVelho.Infra.Data.Repositories
{
    public interface IContatoRepository
    {
        public Task Salvar(Guid idCuidador);
        public int Totalizar();
    }
}
