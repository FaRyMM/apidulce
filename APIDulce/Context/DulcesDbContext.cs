using System;
using APIDulce.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace APIDulce.Context
{
    public class DulcesDbContext : IdentityDbContext
    {
        public DulcesDbContext(DbContextOptions options) : base(options)
        {
        }

        

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<ConfigPrecios> ConfigPrecios { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<EstadoVentas> EstadosVentas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        //public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
    }
}
