using System;
namespace APIDulce.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int CategoriasId { get; set; }
        public int ProveedorId { get; set; }
        public bool Activo { get; set; }

        public virtual CategoriasViewModel Categoria { get; set; }
    }
}
