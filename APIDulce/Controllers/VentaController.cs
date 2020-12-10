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
    public class VentaController
    {
        private readonly DulcesDbContext context;
        private readonly IMapper mapper;

        public VentaController(DulcesDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<VentasViewModel>>> Get()
        {
            var entidades = await context.Ventas.ToListAsync();
            var vm = mapper.Map<List<VentasViewModel>>(entidades).ToList();
            return vm;
        }

        [HttpGet("{id}", Name = "ObtenerVenta")]
        public async Task<ActionResult<VentasViewModel>> Get(int id)
        {
            var entidad = await context.Ventas.FirstOrDefaultAsync(x => x.ID == id);
            if (entidad == null)
            {
                return new NotFoundResult();
            }
            return mapper.Map<VentasViewModel>(entidad);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VentasViewModel vmcreate)
        {
            var entidad = mapper.Map<Ventas>(vmcreate);
            context.Add(entidad);
            await context.SaveChangesAsync();
            var vm = mapper.Map<VentasViewModel>(entidad);
            return new CreatedAtRouteResult("ObtenerVentas", new { id = vm.Id }, vm);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ventas>> Put(int id, [FromBody] VentasViewModel vmcreate)
        {
            var entidad = mapper.Map<Ventas>(vmcreate);
            entidad.ID = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entidad;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Ventas.AnyAsync(opt => opt.ID == id);
            if (!existe)
            {
                return new NotFoundResult();
            }
            context.Remove(new Ventas() { ID = id });
            await context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}