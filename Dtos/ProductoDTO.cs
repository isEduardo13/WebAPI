using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string NombreProducto { get; set; } = null!;

        public int Stock { get; set; }

        public decimal Precio { get; set; }

        public sbyte IdCategoria { get; set; }
    }
}