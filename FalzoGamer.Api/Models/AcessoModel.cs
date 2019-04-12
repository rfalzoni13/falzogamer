using System;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe Model de Acesso
    /// </summary>
    public class AcessoModel
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Acesso
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Indica se o usuário é um novo registro
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

    }
}
