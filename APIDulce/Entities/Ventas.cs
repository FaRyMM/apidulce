using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.Entities
{
    public class Ventas
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int EstadoVentaId { get; set; }
        public double Envio { get; set; }
        public double TotalVenta { get; set; }
        public double TotalImpuesto { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }//fecha en la que se acepta la venta
        public virtual EstadoVentas Estado { get; set; }
    }
}
