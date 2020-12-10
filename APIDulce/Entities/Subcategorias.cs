using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIDulce.Entities
{
    public class Subcategorias
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30)]
        [Required]
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categorias Categoria { get; set; }

    }
}
