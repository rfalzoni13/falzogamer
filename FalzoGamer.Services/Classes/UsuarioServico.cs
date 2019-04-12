using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Repositories;
using FalzoGamer.Domain.Interfaces.Services;
using FalzoGamer.Services.Base;

namespace FalzoGamer.Services.Classes
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
            : base(usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
    }
}
