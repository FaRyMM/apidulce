using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDulce.Validaciones
{
    public class TipoArchivoValidacion : ValidationAttribute
    {
        private readonly string[] TiposValidos;
        public TipoArchivoValidacion(string[] tiposValidos)
        {
            this.TiposValidos = tiposValidos;
        }

        public TipoArchivoValidacion(GrupoTipoArchivo grupoTipoArchivo)
        {
            if (grupoTipoArchivo == GrupoTipoArchivo.Imagen)
            {
                TiposValidos = new string[] { "image/png", "image/jpeg", "image/gif", "image/jpg" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formfile = value as IFormFile;
            if (formfile == null)
            {
                return ValidationResult.Success;
            }
            if (!TiposValidos.Contains(formfile.ContentType))
            {
                return new ValidationResult($"El tipo de archivo debe ser uno de los siguientes: {string.Join(", ", TiposValidos)}");
            }

            return ValidationResult.Success;
        }
    }
}
