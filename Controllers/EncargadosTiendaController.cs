using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI.Dtos;


namespace WebAPI.Controllers
{
    public class EncargadosTiendaController : Controller
    {
        private readonly Jq4bContext bd;
        private readonly IMapper mapper;
        public EncargadosTiendaController(Jq4bContext bd, IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetEncargadosTienda()
        {
            var encargados = await bd.Encargadotienda.ToListAsync();
            return Ok(mapper.Map<List<EncargadoTiendaDTO>>(encargados));
        }
        [HttpPost]
        public async Task<IActionResult> PostEncargadoTienda([FromBody] EncargadoTiendaCreateDTO encargado)
        {
            Encargadotienda e = new Encargadotienda
            {
                Nombre = encargado.Nombre,
                Apepat = encargado.Apepat,
                Apemat = encargado.Apemat,
                Telefono = encargado.Telefono,
                Correo = encargado.Correo,
                Usuario = encargado.Usuario,
                Pwd = encargado.Pwd,
                IdRol = encargado.IdRol
            };
            await bd.Encargadotienda.AddAsync(e);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutEncargadoTienda([FromQuery] sbyte Id, [FromBody] EncargadoTiendaCreateDTO encargado)
        {
            Encargadotienda e = new Encargadotienda
            {
                Id = Id,
                Nombre = encargado.Nombre,
                Apepat = encargado.Apepat,
                Apemat = encargado.Apemat,
                Telefono = encargado.Telefono,
                Correo = encargado.Correo,
                Usuario = encargado.Usuario,
                Pwd = encargado.Pwd,
                IdRol = encargado.IdRol
            };
            bd.Encargadotienda.Update(e);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncargadoTienda(sbyte id)
        {
            var encargado = await bd.Encargadotienda.FindAsync(id);
            bd.Encargadotienda.Remove(encargado!);
            await bd.SaveChangesAsync();
            return Ok();
        }

    }
}