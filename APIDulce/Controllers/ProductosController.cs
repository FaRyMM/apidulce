using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIDulce.Context;
using APIDulce.Entities;
using APIDulce.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDulce.Helpers;
using System.Linq;
using System.IO;
using APIDulce.Servicios;

namespace APIDulce.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly DulcesDbContext context;
        private readonly IMapper mapper;
        private readonly IAlamacenadorArchivos alamacenadorArchivos;

        public ProductosController(DulcesDbContext context, IMapper mapper, IAlamacenadorArchivos almacenadorarchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.alamacenadorArchivos = almacenadorarchivos;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoViewModel>>> Get([FromQuery] PaginacionViewModel paginas)
        {
            var query = context.Productos.Include(pr => pr.Subcategoria).Include(pr => pr.Marca); //.ThenInclude(x => x.Caracteristica);
            var totalRegistros = query.Count();
            var productos = await query
                .Skip(paginas.CantidadRegistrosPorPagina * (paginas.Pagina - 1))
                .Take(paginas.CantidadRegistrosPorPagina)
                .ToListAsync();


            var entidades = await context.Productos.Include(prod => prod.Subcategoria).Include(pr => pr.Marca).ToListAsync();
            //var entidades = await context.Productos.ToListAsync();
            var vm = mapper.Map<List<ProductoViewModel>>(entidades);
            //return entidades;
            return vm;
        }

        [HttpGet("{id}", Name = "ObtenerProducto")]
        public async Task<ActionResult<ProductoViewModel>> Get(int id)
        {
            var entidad = await context.Productos.Include(opt => opt.Subcategoria).FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null)
            {
                return new NotFoundResult();
            }
            return mapper.Map<ProductoViewModel>(entidad);
        }

        [HttpPost]
        public async Task<GetProductoViewModel> Post([FromForm] ProductoViewModel vmcreate)
        {

            var entidad = mapper.Map<Producto>(vmcreate);

            if (vmcreate.Imagen != null)
            {
                using (var memorystream = new MemoryStream())
                {
                    await vmcreate.Imagen.CopyToAsync(memorystream);
                    var contenido = memorystream.ToArray();
                    var extension = Path.GetExtension(vmcreate.Imagen.FileName);
                    entidad.Imagen = await alamacenadorArchivos.GuardarArchivo(contenido, extension, "productos", vmcreate.Imagen.ContentType);
                }
            }

            context.Add(entidad);
            await context.SaveChangesAsync();
            var vm = mapper.Map<GetProductoViewModel>(entidad);
            return vm;

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] ProductoViewModel vm)
        {

            var productoDB = await context.Productos.FirstOrDefaultAsync(x => x.ID == id);

            if(productoDB == null) { return NotFound(); }

            productoDB = mapper.Map(vm, productoDB);

            if (vm.Imagen != null)
            {
                using (var memorystream = new MemoryStream())
                {
                    await vm.Imagen.CopyToAsync(memorystream);
                    var contenido = memorystream.ToArray();
                    var extension = Path.GetExtension(vm.Imagen.FileName);
                    productoDB.Imagen = await alamacenadorArchivos.EditarArchivo(contenido, extension, "productos", productoDB.Imagen, vm.Imagen.ContentType);
                }
            }

            await context.SaveChangesAsync();
            return NoContent();

        }

    }
}
