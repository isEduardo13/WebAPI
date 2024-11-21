using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.services
{
    public class AlmacenamientoLocal : IAlmacenamiento
    
    {
        private readonly IWebHostEnvironment environment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AlmacenamientoLocal(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            this.environment = environment;
            this.httpContextAccessor = httpContextAccessor;
            
        }
        public async Task<string> AlmacenamientoImagen(string contenedor, IFormFile archivo)
        {
            var extension = Path.GetExtension(archivo.FileName);
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            var carpeta = Path.Combine(environment.WebRootPath, contenedor);
            if (!Directory.Exists(carpeta))
            {
                Directory.CreateDirectory(carpeta);
            }
            string ruta = Path.Combine(carpeta, nombreArchivo);
            using (var memoryStream = new MemoryStream()){

                await archivo.CopyToAsync(memoryStream);
                var contenido = memoryStream.ToArray();
                await File.WriteAllBytesAsync(ruta, contenido);
            }
            var request = httpContextAccessor.HttpContext.Request;
            var url = $"{request.Scheme}://{request.Host}";
            var UrlFIle = Path.Combine(url,contenedor,nombreArchivo).Replace("\\","/");
            return UrlFIle;

        }

        public Task Eliminar(string? ruta, string contenedor)
        {
            throw new NotImplementedException();
        }
    }
}