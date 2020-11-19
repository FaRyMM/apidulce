using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDulce.Context;
using APIDulce.Entities;
using APIDulce.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDulce.Controllers
{
    //[EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController
    {
        private readonly DulcesDbContext context;
        private readonly IMapper mapper;

        public CategoriasController(DulcesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<CategoriasViewModel>>> Get()
        {
            var entidades = await context.Categorias.ToListAsync();
            var vm = mapper.Map<List<CategoriasViewModel>>(entidades).ToList();
            return vm;
        }

        [HttpGet("{id}", Name = "ObtenerCategoria")]
        public async Task<ActionResult<CategoriasViewModel>> Get(int id)
        {
            var entidad = await context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if(entidad == null)
            {
                return new NotFoundResult();
            }
            return mapper.Map<CategoriasViewModel>(entidad);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaCreateViewModel vmcreate)
        {
            var entidad = mapper.Map<Categorias>(vmcreate);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var vm = mapper.Map<CategoriasViewModel>(entidad);
            return new CreatedAtRouteResult("ObtenerCategoria", new { id = vm.Id }, vm);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categorias>> Put(int id, [FromBody] CategoriaCreateViewModel vmcreate)
        {
            var entidad = mapper.Map<Categorias>(vmcreate);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entidad;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Categorias.AnyAsync(opt => opt.Id == id);
            if (!existe)
            {
                return new NotFoundResult();
            }
            context.Remove(new Categorias() { Id = id });
            await context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
