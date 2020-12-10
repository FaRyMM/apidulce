using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDulce.Entities
{
    public class Producto
    {
        [Key]
        public int ID { get; set; }
        public string CodProducto { get; set; }
        [Required]
        [MaxLength(80)]
        public string Descripcion { get; set; }
        public int Peso { get; set; }
        [Required]
        public int SubcategoriaId { get; set; }
        public bool Activo { get; set; }
        [Required]
        public int MarcaId { get; set; }
        [Required]
        public string Imagen { get; set; }
        [ForeignKey("SubcategoriaId")]
        public virtual Subcategorias Subcategoria { get; set; }
        public virtual ICollection<ConfigPrecios> Precios {get;set;}
        [ForeignKey("MarcaId")]
        public virtual Marcas Marca { get; set; }
        
        
    }
}
