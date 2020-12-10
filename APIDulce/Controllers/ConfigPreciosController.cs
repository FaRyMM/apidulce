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
    [Route("api/precios")]
    public class ConfigPreciosController
    {
        private readonly DulcesDbContext context;
        private readonly IMapper mapper;

        public ConfigPreciosController(DulcesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ConfigPreciosViewModel>>> Get()
        {
            var entidades = await context.ConfigPrecios.ToListAsync();
            var vm = mapper.Map<List<ConfigPreciosViewModel>>(entidades).ToList();
            return vm;
        }

        [HttpGet("{id}", Name = "ObtenerPrecio")]
        public async Task<ActionResult<ConfigPreciosViewModel>> Get(int id)
        {
            var entidad = await context.ConfigPrecios.FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null)
            {
                return new NotFoundResult();
            }
            return mapper.Map<ConfigPreciosViewModel>(entidad);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConfigPreciosViewModel vmcreate)
        {
            var entidad = mapper.Map<ConfigPrecios>(vmcreate);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var vm = mapper.Map<ConfigPreciosViewModel>(entidad);
            return new CreatedAtRouteResult("ObtenerPrecio", new { id = vm.Id }, vm);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConfigPrecios>> Put(int id, [FromBody] ConfigPreciosViewModel vmcreate)
        {
            var entidad = mapper.Map<ConfigPrecios>(vmcreate);
            entidad.ID = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entidad;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.ConfigPrecios.AnyAsync(opt => opt.ID == id);
            if (!existe)
            {
                return new NotFoundResult();
            }
            context.Remove(new ConfigPrecios() { ID = id });
            await context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}