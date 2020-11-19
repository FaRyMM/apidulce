using System;
using System.ComponentModel.DataAnnotations;

namespace APIDulce.ViewModels
{
    public class CategoriaCreateViewModel
    {
        [Required]
        [StringLength(30)]
        public string nombre { get; set; }
    }
}
