using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.services
{
    public interface IAlmacenamiento
    {
        Task<string> AlmacenamientoImagen(string contenedor,  IFormFile archivo);
        Task Eliminar(string? ruta, string contenedor);
    }
}