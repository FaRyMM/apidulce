using System;
using APIDulce.Entities;
using APIDulce.ViewModels;
using AutoMapper;

namespace APIDulce.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Categorias, CategoriasViewModel>().ReverseMap();
            CreateMap<CategoriaCreateViewModel, Categorias>();
            CreateMap<ConfigPrecios, ConfigPreciosViewModel>().ReverseMap();
            CreateMap<DetalleVenta, DetalleVentaViewModel>().ReverseMap();
            CreateMap<EstadoVentas, EstadoVentasViewModel>().ReverseMap();
            CreateMap<Producto, ProductoViewModel>().ForMember(
                dest => dest.Categoria,
                opt => opt.MapFrom( src => src.Categorias)
                );
            CreateMap<ProductoViewModel, Producto>();
            CreateMap<Ventas, VentasViewModel>().ReverseMap();
        }
    }
}
