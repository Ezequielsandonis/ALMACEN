using ALMACEN.Models.DTOs;
using ALMACEN.Models;
using AutoMapper;


namespace ALMACEN
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<ProductoDto, Producto>();
                Config.CreateMap<Producto, ProductoDto>();
            });

            return mappingConfig;
        }
    }
}
