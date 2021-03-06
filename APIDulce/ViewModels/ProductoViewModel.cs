﻿using APIDulce.Validaciones;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using APIDulce.ViewModels;
using APIDulce.Entities;

namespace APIDulce.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string CodProducto { get; set; }
        public string Descripcion { get; set; }
        public int Peso { get; set; }
        public int SubcategoriaId { get; set; }
        public int ProveedorId { get; set; }
        public int MarcaId { get; set; }
        public bool Activo { get; set; }
        [PesoArchivoValidacion(PesoImagenEnMegaBytes: 4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Imagen { get; set; }

        public virtual SubCategoriasViewModel Subcategoria { get; set; }
        public virtual Marcas Marca { get; set; }
    }
}
