using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class VentaCreateDTO
    {
        public DateTime Fecha { get; set; }

        public string? Hora { get; set; }

        public int IdCliente { get; set; }
    }
}