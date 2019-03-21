using FalzoGamer.Domain.Entities;
using System;
using System.Linq;

namespace FalzoGamer.Domain.Interfaces
{
    public interface IFalzoGamerContext : IDisposable
    {
        IQueryable<Usuario> Usuarios { get; }

        IQueryable<Endereco> Enderecos { get; }

        IQueryable<Cidade> Cidades { get; }

        IQueryable<Estado> Estados { get; }

        IQueryable<Vendedor> Vendedores { get; }

        IQueryable<Produto> Produtos { get; }

        IQueryable<Categoria> Categorias { get; }
    }
}
