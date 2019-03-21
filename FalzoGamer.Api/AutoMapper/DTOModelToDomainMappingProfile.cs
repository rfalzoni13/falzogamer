using AutoMapper;
using FalzoGamer.Api.DTOs;
using FalzoGamer.Domain.Entities;

namespace FalzoGamer.Api.AutoMapper
{
    /// <summary>
    /// 
    /// </summary>
    public class DTOModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// /// <summary>
        /// Método que mapeia dos DTOs para o Domínio
        /// </summary>
        /// </summary>
        public DTOModelToDomainMappingProfile()
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<EnderecoDTO, Endereco>();
            CreateMap<CidadeDTO, Cidade>();
            CreateMap<EstadoDTO, Estado>();
            CreateMap<VendedorDTO, Vendedor>();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<CategoriaDTO, Categoria>();
        }
    }
}
