using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class VentaDTO
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public int IdCliente { get; set; }
    }
}