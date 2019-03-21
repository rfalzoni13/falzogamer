using FalzoGamer.Application.AppServices.Base;
using FalzoGamer.Application.Interfaces;
using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Services;

namespace FalzoGamer.Application.AppServices
{
    public class CategoriaAppServico : BaseAppServico<Categoria>, ICategoriaAppServico
    {
        private readonly ICategoriaServico _categoriaServico;

        public CategoriaAppServico(ICategoriaServico categoriaServico)
            :base(categoriaServico)
        {
            _categoriaServico = categoriaServico;
        }
    }
}
