using FalzoGamer.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace FalzoGamer.Domain.Entities
{
    public class Venda : EntityBase
    {        
        public DateTime DataVenda { get; set; }

        public virtual ICollection<VendaProduto> Vendas { get; set; }
    }
}
