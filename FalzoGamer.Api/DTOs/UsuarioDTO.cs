using System;

namespace FalzoGamer.Api.DTOs
{
    /// <summary>
    /// Classe DTO de Usuário
    /// </summary>
    public class UsuarioDTO
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Sexo do usuário
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Senha { get; set; }

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

        /// <summary>
        /// Objeto de relacionamento endereço
        /// </summary>
        public virtual EnderecoDTO Endereco { get; set; }

        /// <summary>
        /// Objeto de relacionamento cidade
        /// </summary>
        public virtual CidadeDTO Cidade { get; set; }

        /// <summary>
        /// Objeto de relacionamento vendedor
        /// </summary>
        public virtual VendedorDTO Vendedor { get; set; }

    }
}
