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

        public override void Adicionar(Usuario obj)
        {
            obj.Senha = BCrypt.HashPassword(obj.Senha, BCrypt.GenerateSalt());
            base.Adicionar(obj);
        }

        public override void Atualizar(Usuario obj)
        {
            obj.Senha = BCrypt.HashPassword(obj.Senha, BCrypt.GenerateSalt());
            base.Atualizar(obj);
        }
    }
}
