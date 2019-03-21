using FalzoGamer.Domain.Entities.Base;
using System.Collections.Generic;

namespace FalzoGamer.Domain.Entities
{
    public class Estado : EntityBase
    {
        public string Nome { get; set; }

        public char Sigla { get; set; }

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
