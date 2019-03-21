using System;

namespace FalzoGamer.Api.DTOs
{
    /// <summary>
    /// Classe DTO de Endereço
    /// </summary>
    public class EnderecoDTO
    {
        /// <summary>
        /// Id do endereço
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id da chave estrangeira da entidade usuário
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nome da rua
        /// </summary>
        public string Rua { get; set; }

        /// <summary>
        /// Número do endereço
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Complemento do endereço
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro pertencente ao endereço
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Indica se o endereço é um novo registro
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
        public virtual UsuarioDTO Usuario { get; set; }

    }
}
