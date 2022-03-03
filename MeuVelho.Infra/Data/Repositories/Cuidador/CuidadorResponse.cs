using System;
using System.Collections.Generic;
using static MeuVelho.Domains.Enums.MeuVelhoEnums;

namespace MeuVelho.Infra.Data.Repositories
{
    public class CuidadorResponse
    {
        internal CuidadorResponse() { ; }

        public Guid Id { get; internal set; }
        public string Nome { get; internal set; }
        public Sexo Sexo { get; internal set; }
        public string Foto { get; internal set; }
        public string Biografia { get; internal set; }
        public string Whatsapp { get; internal set; }
        public int Contatos { get; internal set; }
        public List<string> Cidades { get; internal set; }
        public string SituacaoCadastro { get; internal set; }
    }
}
