using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using AutoMapper;
using WebAPI.Dtos;


namespace WebAPI.Controllers
{
    [Route("Tiendas")]
    public class TiendasController : Controller
    {
        private readonly Jq4bContext bd;
        private readonly IMapper mapper;
        public TiendasController(Jq4bContext bd, IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetTiendas()
        {
            var tiendas = await bd.Tiendas.ToListAsync();
            return Ok(mapper.Map<List<TiendaDTO>>(tiendas));
        }
        [HttpPost]
        public async Task<IActionResult> PostTienda([FromBody] TiendaCreateDTO tienda)
        {
            Tiendas t = new Tiendas
            {
                NombreTienda = tienda.NombreTienda,
                Direccion = tienda.Direccion,
                Telefono = tienda.Telefono,
                Latitud = tienda.Latitud,
                Longitud = tienda.Longitud,
                IdEncargado = tienda.IdEncargado
            };
            await bd.Tiendas.AddAsync(t);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutTienda([FromQuery] short Id, [FromBody] TiendaCreateDTO tienda)
        {
            Tiendas t = new Tiendas
            {
                Id = Id,
                NombreTienda = tienda.NombreTienda,
                Direccion = tienda.Direccion,
                Telefono = tienda.Telefono,
                Latitud = tienda.Latitud,
                Longitud = tienda.Longitud,
                IdEncargado = tienda.IdEncargado
            };
            bd.Tiendas.Update(t);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTienda(short id)
        {
            var tienda = await bd.Tiendas.FindAsync(id);
            bd.Tiendas.Remove(tienda!);
            await bd.SaveChangesAsync();
            return Ok();
        }

    }
}