using FalzoGamer.Application.AppServices.Base;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Services;

namespace FalzoGamer.Application.AppServices
{
    public class UsuarioAppServico : BaseAppServico<Usuario>, IUsuarioAppServico
    {
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioAppServico(IUsuarioServico usuarioServico)
            :base(usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
    }
}
