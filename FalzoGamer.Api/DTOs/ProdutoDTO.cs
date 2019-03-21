using System;

namespace FalzoGamer.Api.DTOs
{
    /// <summary>
    /// Classe DTO de Produto
    /// </summary>
    public class ProdutoDTO
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
        public virtual CategoriaDTO Categoria { get; set; }

    }
}
