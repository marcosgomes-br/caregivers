using System;
using System.Collections.Generic;

namespace MeuVelho.Infra.Data.Repositories
{
    public class CidadeResponse
    {
        internal CidadeResponse() { ; }
        public Guid Id { get; internal set; }
        public string Nome { get; internal set; }
    }
}
