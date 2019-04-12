using System;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe Model de Produto
    /// </summary>
    public class ProdutoModel
    {
        /// <summary>
        /// Id do produto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id da chave estrangeira da entidade categoria
        /// </summary>
        public int CategoriaId { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Preço do produto
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Marca do produto
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Tipo de produto
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Indica se a categoria é um novo registro
        /// </summary>
        public bool Novo { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Data de modificação
        /// </summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// Objeto de relacionamento categoria
        /// </summary>
        public virtual CategoriaModel Categoria { get; set; }

    }
}
