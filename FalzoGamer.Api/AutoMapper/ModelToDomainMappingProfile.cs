using AutoMapper;
using FalzoGamer.Api.Models;
using FalzoGamer.Domain.Entities;

namespace FalzoGamer.Api.AutoMapper
{
    /// <summary>
    /// Método ModelToDomainMappingProfile
    /// </summary>
    public class ModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Método que mapeia dos DTOs para o Domínio
        /// </summary>
        public ModelToDomainMappingProfile()
        {
            CreateMap<UsuarioModel, Usuario>();
            CreateMap<EnderecoModel, Endereco>();
            CreateMap<CidadeModel, Cidade>();
            CreateMap<EstadoModel, Estado>();
            CreateMap<VendedorModel, Vendedor>();
            CreateMap<ProdutoModel, Produto>();
            CreateMap<CategoriaModel, Categoria>();
        }
    }
}
