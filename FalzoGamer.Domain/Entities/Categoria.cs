using FalzoGamer.Domain.Entities.Base;
using System.Collections.Generic;

namespace FalzoGamer.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
