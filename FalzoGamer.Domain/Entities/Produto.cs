using FalzoGamer.Domain.Entities.Base;

namespace FalzoGamer.Domain.Entities
{
    public class Produto : EntityBase
    {
        public int CategoriaId { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string Marca { get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
