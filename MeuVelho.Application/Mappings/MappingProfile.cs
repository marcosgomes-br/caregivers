using System.Linq;
using AutoMapper;
using MeuVelho.Application.DTOs;
using MeuVelho.Domains;

namespace MeuVelho.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CuidadorDTO, CuidadorDomain>()
                .ConstructUsing(x => new CuidadorDomain(x.Id, x.Nome, x.Sexo, x.Foto, x.Biografia, x.Whatsapp));

            CreateMap<CuidadorDomain, CuidadorDTO>()
                .ConstructUsing(x => new CuidadorDTO
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Sexo = x.Sexo,
                    Biografia = x.Biografia,
                    Whatsapp = x.Whatsapp,
                    Foto = x.Foto,
                    CidadesAtendidas = x.Cidades.Select(s => s.Id).ToList()
                });
        }
    }    
}
