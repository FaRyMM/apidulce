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

namespace APIDulce.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController
    {
        private readonly DulcesDbContext context;
        private readonly IMapper mapper;

        public ProductosController(DulcesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoViewModel>>> Get([FromQuery] PaginacionViewModel paginas)
        {
            var query = context.Productos.AsQueryable().Include(pr => pr.Categorias);
            var totalRegistros = query.Count();
            var productos = await query
                .Skip(paginas.CantidadRegistrosPorPagina * (paginas.Pagina - 1))
                .Take(paginas.CantidadRegistrosPorPagina)
                .ToListAsync();


            var entidades = await context.Productos.Include(prod => prod.Categorias).ToListAsync();
            //var entidades = await context.Productos.ToListAsync();
            var vm = mapper.Map<List<ProductoViewModel>>(entidades);
            //return entidades;
            return vm;
        }

        [HttpGet("{id}", Name = "ObtenerProducto")]
        public async Task<ActionResult<ProductoViewModel>> Get(int id)
        {
            var entidad = await context.Productos.Include(opt => opt.Categorias).FirstOrDefaultAsync(x => x.Id == id);
            if(entidad == null)
            {
                return new NotFoundResult();
            }
            return mapper.Map<ProductoViewModel>(entidad);
        }

        [HttpPost]
        public async Task<ProductoViewModel> Post([FromBody] ProductoViewModel vmcreate)
        {
            var entidad = mapper.Map<Producto>(vmcreate);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var vm = mapper.Map<ProductoViewModel>(entidad);
            return vm;

        }

    }
}
