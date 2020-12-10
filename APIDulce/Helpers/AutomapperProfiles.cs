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
            CreateMap<Proveedor, ProveedorViewModel>().ReverseMap();
            CreateMap<Producto, ProductoViewModel>().ForMember(
                dest => dest.Subcategoria,
                opt => opt.MapFrom(src => src.Subcategoria)
                ).ForMember(dest => dest.Marca,
                opt => opt.MapFrom(src => src.Marca));
            CreateMap<ProductoViewModel, Producto>()
                .ForMember(x => x.Imagen, opt => opt.Ignore());
            CreateMap<Producto, GetProductoViewModel>().ForMember(
                dest => dest.Subcategoria,
                opt => opt.MapFrom(src => src.Subcategoria)
                ).ForMember(dest => dest.Marca,
                opt => opt.MapFrom(src => src.Marca)); ;
            CreateMap<Ventas, VentasViewModel>().ReverseMap();
        }
    }
}
