using MeuVelho.Domains;
using MeuVelho.Application.DTOs;
using System.Threading.Tasks;
using System;
using MeuVelho.Infra.Data.Repositories;
using System.Collections.Generic;

namespace MeuVelho.Application.Services
{
    public interface ICuidadorService
    {
        public Task<Guid> Salvar(CuidadorDTO cuidador);
        public void Desativar(Guid id);
        public Task<CuidadorDTO> Pegar(Guid id);
        public Task<List<CuidadorDTO>> Listar();
    }
}
