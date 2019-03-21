using AutoMapper;

namespace FalzoGamer.Api.AutoMapper
{
    /// <summary>
    /// Classe AutoMapperConfig
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Método RegisterMappings
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToDTOModelMappingProfile>();
                x.AddProfile<DTOModelToDomainMappingProfile>();
            });
        }

    }
}
