﻿using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.Entities
{
    public class EstadoVentas
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
