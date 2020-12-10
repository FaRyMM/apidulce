using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using APIDulce.Context;
using APIDulce.Entities;
using APIDulce.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDulce.Controllers
{
    //[EnableCors("MyAllowSpecificOrigins")]
    [ApiController]
    [Route("api/subcategorias")]
    public class SubCategoriasController
    {
        private readonly DulcesDbContext context;
        private readonly IMapper mapper;

        public SubCategoriasController(DulcesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<SubCategoriasViewModel>>> Get()
        {
            var entidades = await context.Categorias.ToListAsync();
            var vm = mapper.Map<List<SubCategoriasViewModel>>(entidades).ToList();
            return vm;
        }

        [HttpGet("{id}", Name = "ObtenerCategoria")]
        public async Task<ActionResult<SubCategoriasViewModel>> Get(int id)
        {
            var entidad = await context.Subcategorias.FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null)
            {
                return new NotFoundResult();
            }
            return mapper.Map<SubCategoriasViewModel>(entidad);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubCategoriasViewModel vmcreate)
        {
            var entidad = mapper.Map<Subcategorias>(vmcreate);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var vm = mapper.Map<SubCategoriasViewModel>(entidad);
            return new CreatedAtRouteResult("ObtenerCategoria", new { id = vm.ID }, vm);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Subcategorias>> Put(int id, [FromBody] SubCategoriasViewModel vmcreate)
        {
            var entidad = mapper.Map<Subcategorias>(vmcreate);
            entidad.ID = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entidad;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Subcategorias.AnyAsync(opt => opt.ID == id);
            if (!existe)
            {
                return new NotFoundResult();
            }
            context.Remove(new Subcategorias() { ID = id });
            await context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
