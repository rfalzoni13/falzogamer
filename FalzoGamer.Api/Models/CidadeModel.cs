using System;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe Model de Cidade
    /// </summary>

    public class CidadeModel
    {
        /// <summary>
        /// Id da cidade
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id da chave estrangeira da entidade estado
        /// </summary>
        public int EstadoId { get; set; }

        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Indica se a cidade é um novo registro
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
        /// Objeto de relacionamento estado
        /// </summary>
        public virtual EstadoModel Estado { get; set; }

    }
}
