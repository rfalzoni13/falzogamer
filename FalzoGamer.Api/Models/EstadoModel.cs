using System;
using System.Collections.Generic;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe Model de Estado
    /// </summary>
    public class EstadoModel
    {
        /// <summary>
        /// Id do estado
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do estado
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sigla do estado
        /// </summary>
        public char Sigla { get; set; }

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
        /// Lista de objetos de relacionamento cidade
        /// </summary>
        public virtual ICollection<CidadeModel> Cidades { get; set; }

    }
}
