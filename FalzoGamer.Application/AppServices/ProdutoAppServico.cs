using FalzoGamer.Application.AppServices.Base;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Services;

namespace FalzoGamer.Application.AppServices
{
    public class ProdutoAppServico : BaseAppServico<Produto>, IProdutoAppServico
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoAppServico(IProdutoServico produtoServico)
            :base(produtoServico)
        {
            _produtoServico = produtoServico;
        }
    }
}
