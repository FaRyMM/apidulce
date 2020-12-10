using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDulce.Validaciones
{
    public class PesoArchivoValidacion : ValidationAttribute
    {
        private readonly int pesoMaximoEnMegaBytes;

        public PesoArchivoValidacion(int PesoImagenEnMegaBytes)
        {
            pesoMaximoEnMegaBytes = PesoImagenEnMegaBytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formfile = value as IFormFile;
            if(formfile == null)
            {
                return ValidationResult.Success;
            }
            if(formfile.Length > pesoMaximoEnMegaBytes * 1024  * 1024)
            {
                return new ValidationResult($"El peso del archivo no puede ser mayor a {pesoMaximoEnMegaBytes}mb");
            }
            return ValidationResult.Success;
        }
    }
}
