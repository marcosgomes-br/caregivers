using MeuVelho.Application.DTOs;
using MeuVelho.Domains;
using MeuVelho.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MeuVelho.Application.Services
{
    public class CaregiverService : ICaregiverService
    {
        private readonly ICuidadorRepository cuidadorRepository;

        private readonly IMapper mapper;
        public CaregiverService(ICuidadorRepository _cuidadorRepository, IMapper _mapper)
        {
            cuidadorRepository = _cuidadorRepository;
            mapper = _mapper;
        }

        public void Disable(Guid id)
        {
            cuidadorRepository.Desativar(id);
        }

        public async Task<List<CaregiverDto>> Get()
        {
            return mapper.Map<List<CaregiverDto>>(await cuidadorRepository.Listar());
        }

        public async Task<CaregiverDto> Get(Guid id)
        {
            return mapper.Map<CaregiverDto>(await cuidadorRepository.Pegar(id));
        }

        public async Task<Guid> Save(CaregiverDto caregiver)
        {
            //var domain = mapper.Map<CuidadorDomain>(cuidador); 
            var domain = new CuidadorDomain(caregiver.Id, caregiver.FullName, caregiver.Gender, caregiver.Photo, caregiver.Biography, caregiver.Whatsapp);
            domain.CuidadoresCidade = caregiver.CitiesServed.Select(x => new CuidadorCidadeDomain(caregiver.Id, x.Id))
                                                               .ToList();
            await cuidadorRepository.Salvar(domain);
            return domain.Id;
        }
    }
}
