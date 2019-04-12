using System;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe Model de Usuário
    /// </summary>
    public class UsuarioModel
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id de acesso
        /// </summary>
        public int AcessoId { get; set; }

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
        public virtual EnderecoModel Endereco { get; set; }

        /// <summary>
        /// Objeto de relacionamento cidade
        /// </summary>
        public virtual CidadeModel Cidade { get; set; }

        /// <summary>
        /// Objeto de relacionamento vendedor
        /// </summary>
        public virtual VendedorModel Vendedor { get; set; }

    }
}
