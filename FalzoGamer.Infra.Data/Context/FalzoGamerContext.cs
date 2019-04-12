using FalzoGamer.Domain.Entities;
using FalzoGamer.Domain.Interfaces;
using FalzoGamer.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace FalzoGamer.Infra.Data.Context
{
    public class FalzoGamerContext : DbContext, IFalzoGamerContext
    {
        #region Attributes
        public virtual DbSet<Acesso> Acessos { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Endereco> Enderecos { get; set; }

        public virtual DbSet<Cidade> Cidades { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Vendedor> Vendedores { get; set; }

        public virtual DbSet<Venda> Vendas { get; set; }

        public virtual DbSet<Produto> Produtos { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }
        #endregion

        #region Interfaces
        IQueryable<Acesso> IFalzoGamerContext.Acessos => Acessos;

        IQueryable<Usuario> IFalzoGamerContext.Usuarios => Usuarios;

        IQueryable<Endereco> IFalzoGamerContext.Enderecos => Enderecos;

        IQueryable<Cidade> IFalzoGamerContext.Cidades => Cidades;

        IQueryable<Estado> IFalzoGamerContext.Estados => Estados;

        IQueryable<Vendedor> IFalzoGamerContext.Vendedores => Vendedores;

        IQueryable<Venda> IFalzoGamerContext.Vendas => Vendas;

        IQueryable<Produto> IFalzoGamerContext.Produtos => Produtos;

        IQueryable<Categoria> IFalzoGamerContext.Categorias => Categorias;
        #endregion

        #region Constructor
        public FalzoGamerContext()
        {
            Database.Migrate();
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach(IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.DisplayName();
            }

            modelBuilder.Entity<VendaProduto>().HasKey(x => new { x.ProdutoId, x.VendaId });

            modelBuilder.Entity<VendaProduto>().HasOne(vp => vp.Venda).WithMany(v => v.Vendas).HasForeignKey(vp => vp.VendaId);

            modelBuilder.Entity<VendaProduto>().HasOne(vp => vp.Produto).WithMany(p => p.Produtos).HasForeignKey(vp => vp.ProdutoId);

            modelBuilder.Entity<Acesso>(new AcessoConfiguracao().Configure);

            modelBuilder.Entity<Usuario>(new UsuarioConfiguracao().Configure);

            modelBuilder.Entity<Endereco>(new EnderecoConfiguracao().Configure);

            modelBuilder.Entity<Cidade>(new CidadeConfiguracao().Configure);

            modelBuilder.Entity<Estado>(new EstadoConfiguracao().Configure);

            modelBuilder.Entity<Venda>(new VendaConfiguracao().Configure);

            modelBuilder.Entity<Vendedor>(new VendedorConfiguracao().Configure);

            modelBuilder.Entity<Produto>(new ProdutoConfiguracao().Configure);

            modelBuilder.Entity<Categoria>(new CategoriaConfiguracao().Configure);
        }
    }
}
