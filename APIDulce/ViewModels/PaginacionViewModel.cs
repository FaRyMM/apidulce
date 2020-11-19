using System;
namespace APIDulce.ViewModels
{
    public class PaginacionViewModel
    {
        public int Pagina { get; set; } = 1;
        private int cantidadRegistrosPorPagina = 10;
        private readonly int CantidadRegistroMaximosPorPagina = 50;
        public int CantidadRegistrosPorPagina
        {
            get => cantidadRegistrosPorPagina;
            set
            {
                cantidadRegistrosPorPagina = (value > CantidadRegistroMaximosPorPagina ? cantidadRegistrosPorPagina : value);
            }
        }
    }
}