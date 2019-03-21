using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Repositories;
using FalzoGamer.Domain.Interfaces.Services;
using FalzoGamer.Services.Base;

namespace FalzoGamer.Services.Classes
{
    public class ProdutoServico : ServicoBase<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
            : base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
    }
}
