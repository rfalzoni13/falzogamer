using FalzoGamer.Application.AppServices.Base;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Services;

namespace FalzoGamer.Application.AppServices
{
    public class AcessoAppServico : BaseAppServico<Acesso>, IAcessoAppServico
    {
        private readonly IAcessoServico _acessoServico;

        public AcessoAppServico(IAcessoServico acessoServico)
            : base(acessoServico)
        {
            _acessoServico = acessoServico;
        }
    }
}
