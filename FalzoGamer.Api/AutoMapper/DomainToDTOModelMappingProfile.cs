using AutoMapper;
using FalzoGamer.Api.DTOs;
using FalzoGamer.Domain.Entities;

namespace FalzoGamer.Api.AutoMapper
{
    /// <summary>
    /// Método DomainToDTOModelMappingProfile
    /// </summary>
    public class DomainToDTOModelMappingProfile : Profile
    {
        /// <summary>
        /// Método que mapeia do Domínio para os DTOs
        /// </summary>
        public DomainToDTOModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Endereco, EnderecoDTO>();
            CreateMap<Cidade, CidadeDTO>();
            CreateMap<Estado, EstadoDTO>();
            CreateMap<Vendedor, VendedorDTO>();
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
