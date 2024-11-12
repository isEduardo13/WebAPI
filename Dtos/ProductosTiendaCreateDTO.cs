using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class ProductosTiendaCreateDTO
    {
        public short IdTienda { get; set; }

        public int IdProducto { get; set; }
    }
}