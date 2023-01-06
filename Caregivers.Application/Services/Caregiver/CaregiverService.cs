using Caregivers.Application.DTOs;
using Caregivers.Domains;
using Caregivers.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Caregivers.Application.Services
{
    public class CaregiverService : ICaregiverService
    {
        private readonly ICaregiverRepository _caregiverRepository;

        private readonly IMapper _mapper;
        public CaregiverService(ICaregiverRepository caregiverRepository, IMapper mapper)
        {
            _caregiverRepository = caregiverRepository;
            _mapper = mapper;
        }

        public void Disable(Guid id)
        {
            _caregiverRepository.Disable(id);
        }

        public async Task<List<CaregiverDto>> Get()
        {
            return _mapper.Map<List<CaregiverDto>>(await _caregiverRepository.Get());
        }

        public async Task<CaregiverDto> Get(Guid id)
        {
            return _mapper.Map<CaregiverDto>(await _caregiverRepository.Get(id));
        }

        public async Task<Guid> Save(CaregiverDto caregiver)
        {
            //var domain = mapper.Map<CuidadorDomain>(cuidador); 
            var domain = new CaregiverDomain(caregiver.Id, caregiver.FullName, caregiver.Gender, 
                                        caregiver.Photo, caregiver.Biography, caregiver.Whatsapp)
                {
                    CaregiversCities = caregiver.CitiesServed.Select(x => new CaregiverCityDomain(caregiver.Id, x.Id))
                        .ToList()
                };
            await _caregiverRepository.Save(domain);
            return domain.Id;
        }
    }
}
