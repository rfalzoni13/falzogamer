using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Repositories;
using FalzoGamer.Domain.Interfaces.Services;
using FalzoGamer.Services.Base;

namespace FalzoGamer.Services.Classes
{
    public class AcessoServico : ServicoBase<Acesso>, IAcessoServico
    {
        private readonly IAcessoRepositorio _acessoRepositorio;
        public AcessoServico(IAcessoRepositorio acessoRepositorio)
            : base(acessoRepositorio)
        {
            _acessoRepositorio = acessoRepositorio;
        }
    }
}
