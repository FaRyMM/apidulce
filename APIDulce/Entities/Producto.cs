using System;
using System.Collections.Generic;

namespace APIDulce.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int CategoriasId { get; set; }
        public int ProveedorId { get; set; }
        public bool Activo { get; set; }

        public virtual Categorias Categorias { get; set; }
        
    }
}
