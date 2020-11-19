using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.ViewModels
{
    public class CategoriasViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string nombre { get; set; }
        public bool Subcategoria { get; set; }
    }
}
