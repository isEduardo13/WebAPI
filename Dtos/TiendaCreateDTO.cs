using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class TiendaCreateDTO
    {
        public string NombreTienda { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public decimal? Latitud { get; set; }

        public decimal? Longitud { get; set; }

        public string Telefono { get; set; } = null!;

        public short IdEncargado { get; set; }
    }
}