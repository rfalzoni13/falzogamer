using System.Collections.Generic;

namespace FalzoGamer.Domain.Entities
{
    public class VendaProduto
    {
        public int VendaId { get; set; }

        public virtual Venda Venda { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
