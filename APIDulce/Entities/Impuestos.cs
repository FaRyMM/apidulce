using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDulce.Entities
{
    public class Impuestos
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int valor { get; set; }
    }
}
