using MeuVelho.Application.DTOs;
using MeuVelho.Domains;
using MeuVelho.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuVelho.Application.Services
{
    public class CuidadorService : ICuidadorService
    {
        private readonly ICuidadorRepository cuidadorRepository;

        public CuidadorService(ICuidadorRepository _cuidadorRepository)
        {
            cuidadorRepository = _cuidadorRepository;
        }

        public void Desativar(Guid id)
        {
            cuidadorRepository.Desativar(id);
        }

        public async Task<List<CuidadorResponse>> Listar()
        {
            return await cuidadorRepository.Listar();
        }

        public async Task<CuidadorResponse> Pegar(Guid id)
        {
            return await cuidadorRepository.Pegar(id);
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
