using System.Collections.Generic;
using System.Threading.Tasks;
using Caregivers.Domains;

namespace Caregivers.Infra.Data.Repositories
{
    public interface ICityRepository
    {
        public Task<List<CityDomain>> Get();
    }
}
