using System;
namespace APIDulce.ViewModels
{
        public class ConfigPreciosViewModel
        {
            public int Id { get; set; }
            public int ProductoId { get; set; }
            public int Cantidad { get; set; }
            public double PrecioCompra { get; set; }
            public double PrecioVenta { get; set; }
            public DateTime FechaDesde { get; set; }
            public DateTime FechaHasta { get; set; }

            public virtual ProductoViewModel Producto { get; set; }
            
        }
}
