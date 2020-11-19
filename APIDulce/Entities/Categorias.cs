using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.Entities
{
        public class Categorias
        {
            public int Id { get; set; }
            [Required]
            [StringLength(30)]
            public string nombre { get; set; }
        }
  
}
