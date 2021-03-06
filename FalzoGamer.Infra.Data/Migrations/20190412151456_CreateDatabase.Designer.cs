﻿// <auto-generated />
using System;
using FalzoGamer.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FalzoGamer.Infra.Data.Migrations
{
    [DbContext(typeof(FalzoGamerContext))]
    [Migration("20190412151456_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Acesso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Novo");

                    b.HasKey("Id");

                    b.ToTable("Acesso");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Novo");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<int>("EstadoId");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<bool>("Novo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(110);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<bool>("Novo");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(440);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<bool>("Novo");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<bool>("Novo");

                    b.Property<decimal>("Preco");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcessoId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(220);

                    b.Property<bool>("Novo");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AcessoId")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DataVenda");

                    b.Property<DateTime?>("Modified");

                    b.Property<bool>("Novo");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.VendaProduto", b =>
                {
                    b.Property<int>("ProdutoId");

                    b.Property<int>("VendaId");

                    b.HasKey("ProdutoId", "VendaId");

                    b.HasIndex("VendaId");

                    b.ToTable("VendaProduto");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Celular");

                    b.Property<long>("Cpf");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<bool>("Novo");

                    b.Property<long?>("Telefone");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Cidade", b =>
                {
                    b.HasOne("FalzoGamer.Domain.Entities.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FalzoGamer.Domain.Entities.Usuario")
                        .WithOne("Cidade")
                        .HasForeignKey("FalzoGamer.Domain.Entities.Cidade", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("FalzoGamer.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("FalzoGamer.Domain.Entities.Endereco", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Produto", b =>
                {
                    b.HasOne("FalzoGamer.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Usuario", b =>
                {
                    b.HasOne("FalzoGamer.Domain.Entities.Acesso", "Acesso")
                        .WithOne("Usuario")
                        .HasForeignKey("FalzoGamer.Domain.Entities.Usuario", "AcessoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.VendaProduto", b =>
                {
                    b.HasOne("FalzoGamer.Domain.Entities.Produto", "Produto")
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FalzoGamer.Domain.Entities.Venda", "Venda")
                        .WithMany("Vendas")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FalzoGamer.Domain.Entities.Vendedor", b =>
                {
                    b.HasOne("FalzoGamer.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Vendedor")
                        .HasForeignKey("FalzoGamer.Domain.Entities.Vendedor", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
