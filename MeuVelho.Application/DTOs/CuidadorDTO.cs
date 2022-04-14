using System;
using System.Collections.Generic;
using static MeuVelho.Domains.Enums.MeuVelhoEnums;

namespace MeuVelho.Application.DTOs
{
    public class CuidadorDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Foto { get; set; }
        public string Biografia { get; set; }
        public string Whatsapp { get; set; }
        public List<Guid> CidadesAtendidas { get; set; }
    }
}
