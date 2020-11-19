using System;
namespace APIDulce.ViewModels
{
    public class DetalleVentaViewModel
    {
        public int Id { get; set; }
        public int VentasId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double TotalIpsi { get; set; }
        public double Total { get; set; }

        public virtual VentasViewModel Venta { get; set; }
        public virtual ProductoViewModel Producto { get; set; }

    }
}
