using System;
namespace APIDulce.Entities
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentasId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double TotalIpsi { get; set; }
        public double Total { get; set; }

        public virtual Ventas Venta { get; set; }
        public virtual Producto Producto { get; set; } 
    }
}
