using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.Entities
{
    public class ConfigPrecios
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ProductoId { get; set; }
        public double PrecioCompra { get; set; }
        public int ImpuestoId { get; set; }
        public double PrecioVenta { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Impuestos Impuesto { get; set; }
    }
}
