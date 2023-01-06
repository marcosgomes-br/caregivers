using System.Collections.Generic;
using System.Threading.Tasks;
using Caregivers.Application.DTOs;

namespace Caregivers.Application.Services
{
    public interface ICityService
    {
        public Task<List<CityDto>> Get();
    }
}
