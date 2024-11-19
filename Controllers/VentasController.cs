using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cms;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    
    [Route("Ventas")]
    public class VentasController : Controller
    {
        private readonly Jq4bContext bd;
        private readonly IMapper mapper;
        public VentasController(Jq4bContext bd, IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(int id)
        {
            var venta = await bd.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<VentaDTO>(venta));
        }
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var ventas = await bd.Ventas.ToListAsync();
            return Ok(mapper.Map<List<VentaDTO>>(ventas));    
        }
        [HttpPost]
        public async Task<IActionResult> PostVenta([FromBody] VentaCreateDTO venta)
        {
            Ventas v = new Ventas
            {
                Fecha = venta.Fecha,
                Hora = TimeSpan.Parse(venta.Hora!),
                IdCliente = venta.IdCliente
            };
            await bd.Ventas.AddAsync(v);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutVenta([FromQuery] int Id, [FromBody] VentaCreateDTO venta)
        {
            Ventas v = new Ventas
            {
                Id = Id,
                Fecha = venta.Fecha,
                Hora = TimeSpan.Parse(venta.Hora!),
                IdCliente = venta.IdCliente
            };
            bd.Ventas.Update(v);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var venta = await bd.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            bd.Ventas.Remove(venta);
            await bd.SaveChangesAsync();
            return Ok();
        }

        
    }
}