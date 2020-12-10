using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDulce.Entities
{
    public class Marcas
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
