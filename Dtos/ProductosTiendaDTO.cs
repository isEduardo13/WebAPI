using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class ProductosTiendaDTO
    {
        public int Id { get; set; }

        public short IdTienda { get; set; }

        public int IdProducto { get; set; }
    }
}