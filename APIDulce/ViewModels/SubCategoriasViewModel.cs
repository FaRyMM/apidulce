using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDulce.ViewModels
{
    public class SubCategoriasViewModel
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public virtual CategoriasViewModel Categoria { get; set; }

    }
}
