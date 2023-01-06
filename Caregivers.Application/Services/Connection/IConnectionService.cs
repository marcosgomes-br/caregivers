using System;
using System.Threading.Tasks;

namespace Caregivers.Application.Services
{
    public interface IConnectionService
    {
        public Task Save(Guid idCaregiver);
        public int Count();
    }
}
