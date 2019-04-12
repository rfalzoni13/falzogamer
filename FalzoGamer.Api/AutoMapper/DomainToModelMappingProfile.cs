using AutoMapper;
using FalzoGamer.Api.Models;
using FalzoGamer.Domain.Entities;

namespace FalzoGamer.Api.AutoMapper
{
    /// <summary>
    /// Método DomainToDTOModelMappingProfile
    /// </summary>
    public class DomainToModelMappingProfile : Profile
    {
        /// <summary>
        /// Método que mapeia do Domínio para os DTOs
        /// </summary>
        public DomainToModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioModel>();
            CreateMap<Endereco, EnderecoModel>();
            CreateMap<Cidade, CidadeModel>();
            CreateMap<Estado, EstadoModel>();
            CreateMap<Vendedor, VendedorModel>();
            CreateMap<Produto, ProdutoModel>();
            CreateMap<Categoria, CategoriaModel>();
        }
    }
}
