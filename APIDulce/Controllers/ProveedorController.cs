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
    [Route("api/proveedor")]
    public class ProveedorController
    {
        private readonly DulcesDbContext context;
        private readonly IMapper mapper;

        public ProveedorController(DulcesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProveedorViewModel>>> Get()
        {
            var entidades = await context.Proveedores.ToListAsync();
            var vm = mapper.Map<List<ProveedorViewModel>>(entidades).ToList();
            return vm;
        }

        [HttpGet("{id}", Name = "ObtenerProveedor")]
        public async Task<ActionResult<ProveedorViewModel>> Get(int id)
        {
            var entidad = await context.Proveedores.FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null)
            {
                return new NotFoundResult();
            }
            return mapper.Map<ProveedorViewModel>(entidad);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProveedorViewModel vmcreate)
        {
            var entidad = mapper.Map<Proveedor>(vmcreate);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var vm = mapper.Map<ProveedorViewModel>(entidad);
            return new CreatedAtRouteResult("ObtenerProveedor", new { id = vm.Id }, vm);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Proveedor>> Put(int id, [FromBody] ProveedorViewModel vmcreate)
        {
            var entidad = mapper.Map<Proveedor>(vmcreate);
            entidad.ID = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entidad;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Proveedores.AnyAsync(opt => opt.ID == id);
            if (!existe)
            {
                return new NotFoundResult();
            }
            context.Remove(new Proveedor() { ID = id });
            await context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}