using System;
using System.Net;

namespace FalzoGamer.Api.Models
{
    /// <summary>
    /// Classe ObjectResponse
    /// </summary>
    public class ObjectResponse
    {
        /// <summary>
        /// Código de Status da Response
        /// </summary>
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; set; }
    }
}
