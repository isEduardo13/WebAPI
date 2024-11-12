using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class RolDTO
    {
        public sbyte Id { get; set; }

        public string Rol { get; set; } = null!;
    }
}