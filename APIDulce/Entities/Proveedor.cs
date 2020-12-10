using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.Entities
{
    public class Proveedor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
    }
}
