﻿using System;
namespace APIDulce.Entities
{
    public class Ventas
    {
        public int Id { get; set; }
        public int EstadoVentaId { get; set; }
        public double TotalVenta { get; set; }
        public double TotalIpsi { get; set; }
        public int UserId { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual EstadoVentas Estado { get; set; }
    }
}
