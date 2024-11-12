using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class ClienteCreateDTO
    {
        public string Nombre { get; set; } = null!;

        public string Apepat { get; set; } = null!;

        public string Apemat { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Usuario { get; set; } = null!;

        public string Pwd { get; set; } = null!;
    }
}