using System.ComponentModel.DataAnnotations;

namespace ALMACEN.Models.DTOs
{
    public class ProductoDto
    {
        [Key]
        public int Id { get; set; } 
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
    }
}
