using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.Entities
{
    public class DetalleVenta
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int VentasId { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int Descuento { get; set; }
        public int ImpuestoId { get; set; }
        public double TotalImpuesto { get; set; }
        public double Total { get; set; }

        public virtual Ventas Venta { get; set; }
        public virtual Producto Producto { get; set; } 
        public virtual Impuestos Impuesto { get; set; }
    }
}
