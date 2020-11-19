using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.Entities
{
    public class ConfigPrecios
    {
        public int Id { get; set; }
        [Required]
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
