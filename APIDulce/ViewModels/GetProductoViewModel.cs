using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDulce.Entities;
using APIDulce.ViewModels;

namespace APIDulce.ViewModels
{
    public class GetProductoViewModel
    {
        public int Id { get; set; }
        public string CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int SubcategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public bool Activo { get; set; }
        public int MarcaId { get; set; }
        public string Imagen { get; set; }

        public virtual SubCategoriasViewModel Subcategoria { get; set; }
        public virtual Marcas Marca { get; set; }
    }
}
