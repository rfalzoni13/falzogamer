using System;
using System.Collections.Generic;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe Model de Categoria
    /// </summary>
    public class CategoriaModel
    {
        /// <summary>
        /// Id da categoria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string Nome { get; set; }

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
        /// Lista de objetos de relacionamento produto
        /// </summary>
        public virtual ICollection<ProdutoModel> Produtos { get; set; }

    }
}
