using MeuVelho.Application.DTOs;
using MeuVelho.Domains;
using MeuVelho.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace MeuVelho.Application.Services
{
    public class CuidadorService : ICuidadorService
    {
        private readonly ICuidadorRepository cuidadorRepository;

        private readonly IMapper mapper;
        public CuidadorService(ICuidadorRepository _cuidadorRepository, IMapper _mapper)
        {
            cuidadorRepository = _cuidadorRepository;
            mapper = _mapper;
        }

        public void Desativar(Guid id)
        {
            cuidadorRepository.Desativar(id);
        }

        public async Task<List<CuidadorDTO>> Listar()
        {
            return mapper.Map<List<CuidadorDTO>>(await cuidadorRepository.Listar());
        }

        public async Task<CuidadorDTO> Pegar(Guid id)
        {
            return mapper.Map<CuidadorDTO>(await cuidadorRepository.Pegar(id));
        }

        public async Task<Guid> Salvar(CuidadorDTO cuidador)
        {
            var domain = new CuidadorDomain(cuidador.Id, cuidador.Nome, cuidador.Sexo, cuidador.Foto, cuidador.Biografia, cuidador.Whatsapp);
            domain.CuidadoresCidade = new List<CuidadorCidadeDomain>();
            foreach (var cidade in cuidador.CidadesAtendidas)
                domain.CuidadoresCidade.Add(new CuidadorCidadeDomain(cuidador.Id, cidade));

            await cuidadorRepository.Salvar(domain);
            return domain.Id;
        }
    }
}
