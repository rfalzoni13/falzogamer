using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces.Repositories;
using FalzoGamer.Domain.Interfaces.Services;
using FalzoGamer.Services.Base;

namespace FalzoGamer.Services.Classes
{
    public class CategoriaServico : ServicoBase<Categoria>, ICategoriaServico
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
            : base(categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
    }
}
