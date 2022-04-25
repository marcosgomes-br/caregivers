using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVelho.Application.DTOs;

namespace MeuVelho.Application.Services
{
    public interface ICityService
    {
        public Task<List<CityDto>> Get();
    }
}
