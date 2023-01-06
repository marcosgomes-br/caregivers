using System;
using System.Threading.Tasks;

namespace Caregivers.Infra.Data.Repositories
{
    public interface IConnectionRepository
    {
        public Task Save(Guid idCaregiver);
        public int Count();
    }
}
