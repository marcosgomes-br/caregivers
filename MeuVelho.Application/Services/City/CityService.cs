using MeuVelho.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVelho.Application.DTOs;
using AutoMapper;

namespace MeuVelho.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<List<CityDto>> Get()
        {
            return _mapper.Map<List<CityDto>>(await _cityRepository.Get());
        }
    }
}
