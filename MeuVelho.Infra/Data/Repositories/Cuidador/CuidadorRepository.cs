using MeuVelho.Domains;
using MeuVelho.Infra.Data.Contexts;
using MeuVelho.Domains.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace MeuVelho.Infra.Data.Repositories
{
    public class CuidadorRepository : ICuidadorRepository
    {
        private readonly MeuVelhoContext contexto = new MeuVelhoContext();

        public void Desativar(Guid id)
        {
            var cuidador = contexto.Cuidadores.AsTracking().Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (cuidador == null)
                throw new ValidationException("Falha ao desativar colaborador, cadastro inexistente.");
            cuidador.Desativar();
            contexto.SaveChangesAsync();
        }

        public async Task<List<CuidadorDomain>> Listar()
        {
            return await contexto.Cuidadores.Include(x => x.Cidades).OrderBy(o => o.Nome).ToListAsync();
        }

        public async Task<CuidadorDomain> Pegar(Guid id)
        {
            return await contexto.Cuidadores.Where(x => x.Id.Equals(id))
                                            .Include(x => x.Cidades)
                                            .FirstOrDefaultAsync();
        }

        public async Task<CuidadorDomain> Salvar(CuidadorDomain cuidador)
        {
            var existeNoBanco = contexto.Cuidadores.Any(x => x.Id == cuidador.Id);
            if (existeNoBanco)
                contexto.Update(cuidador);
            else
                contexto.Cuidadores.Add(cuidador);
            await contexto.SaveChangesAsync();
            return cuidador;
        }
    }
}
