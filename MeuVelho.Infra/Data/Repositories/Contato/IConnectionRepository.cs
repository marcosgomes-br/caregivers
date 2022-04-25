using System;
using System.Threading.Tasks;

namespace MeuVelho.Infra.Data.Repositories
{
    public interface IConnectionRepository
    {
        public Task Save(Guid idCaregiver);
        public int Count();
    }
}
