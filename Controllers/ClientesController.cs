using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos;


namespace WebAPI.Controllers
{
    
    [Route("Clientes")]
    public class ClientesController : ControllerBase
    {
        private  readonly Jq4bContext bd;
        private readonly IMapper mapper;
        public ClientesController(Jq4bContext bd, IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await bd.Clientes.ToListAsync();
            return Ok(mapper.Map<List<ClienteDTO>>(clientes));
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente([FromBody]ClienteCreateDTO cliente)
        {
            Clientes c = new Clientes
            {
                Nombre = cliente.Nombre,
                Apepat = cliente.Apepat,
                Apemat = cliente.Apemat,
                Telefono = cliente.Telefono,
                Correo = cliente.Correo,
                Usuario = cliente.Usuario,
                Pwd = cliente.Pwd
            };
            await bd.Clientes.AddAsync(c);
            await bd.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente([FromQuery] int Id, [FromBody] ClienteCreateDTO cliente)
        {
            Clientes c = new Clientes
            {
                Id = Id,
                Nombre = cliente.Nombre,
                Apepat = cliente.Apepat,
                Apemat = cliente.Apemat,
                Telefono = cliente.Telefono,
                Correo = cliente.Correo,
                Usuario = cliente.Usuario,
                Pwd = cliente.Pwd
            };
            bd.Clientes.Update(c);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await bd.Clientes.FindAsync(id);
            bd.Clientes.Remove(cliente!);
            await bd.SaveChangesAsync();
            return Ok();
        }

    }
}