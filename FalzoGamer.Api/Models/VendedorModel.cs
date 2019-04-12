using System;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe Model de Vendedor
    /// </summary>
    public class VendedorModel
    {
        /// <summary>
        /// Id do vendedor
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id da chave estrangeira da entidade usuário
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// CPF do vendedor
        /// </summary>
        public long Cpf { get; set; }

        /// <summary>
        /// Telefone do vendedor
        /// </summary>
        public long? Telefone { get; set; }

        /// <summary>
        /// Celular do vendedor
        /// </summary>
        public long Celular { get; set; }

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
        /// Objeto de relacionamento usuário
        /// </summary>
        public virtual UsuarioModel Usuario { get; set; }

    }
}
