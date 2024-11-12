using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class CategoriaDTO
    {
        public sbyte Id { get; set; }

        public string NombreCategoria { get; set; } = null!;

    }
}