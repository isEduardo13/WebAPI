using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class DetalleVentaDTO
    {
        public int Id { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public int IdVenta { get; set; }

        public int IdProducto { get; set; }


    }
}