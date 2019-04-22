using System;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Objeto TokenResponse
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// Token de acesso
        /// </summary>
        public string AcessToken { get; set; }

        /// <summary>
        /// Data de criação do Token
        /// </summary>
        public string Created { get; set; }

        /// <summary>
        /// Data de expiração do Token
        /// </summary>
        public string Expiration { get; set; }
    }
}
