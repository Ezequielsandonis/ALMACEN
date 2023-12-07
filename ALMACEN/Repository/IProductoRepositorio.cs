using ALMACEN.Models.DTOs;

namespace ALMACEN.Repository
{
    public interface IProductoRepositorio
    {
        Task<List<ProductoDto>> GetProductos();
        Task<ProductoDto> GetProducto(int id);
        Task<ProductoDto> CrearOActualizar(ProductoDto producto, int id = 0);
        Task<bool> EliminarProducto(int id);
    }
}
