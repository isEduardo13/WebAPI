using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos;


namespace WebAPI.Controllers
{
    [Route("DetalleVentas")]
    public class DetalleVentasController : Controller
    {
        private readonly Jq4bContext bd;

        private readonly IMapper mapper;
        public DetalleVentasController(Jq4bContext bd , IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleVentaById(int id)
        {
            var detalleventa = await bd.Detalleventas.FindAsync(id);
            return Ok(mapper.Map<DetalleVentaDTO>(detalleventa));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetalleVentas()
        {
            var detalleventas = await bd.Detalleventas.ToListAsync();
            return Ok(mapper.Map<List<DetalleVentaDTO>>(detalleventas));
        }
        [HttpPost]
        public async Task<IActionResult> PostDetalleVenta([FromBody]DetalleVentaCreateDTO detalleventa)
        {
            Detalleventas dv = new Detalleventas
            {
                Precio = detalleventa.Precio,
                Cantidad = detalleventa.Cantidad,
                IdVenta = detalleventa.IdVenta,
                IdProducto = detalleventa.IdProducto
            };
            await bd.Detalleventas.AddAsync(dv);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetalleVenta([FromQuery] int Id, [FromBody] DetalleVentaCreateDTO detalleventa)
        {
            Detalleventas dv = new Detalleventas
            {
                Id = Id,
                Precio = detalleventa.Precio,
                Cantidad = detalleventa.Cantidad,
                IdVenta = detalleventa.IdVenta,
                IdProducto = detalleventa.IdProducto
            };
            bd.Detalleventas.Update(dv);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(int id)
        {
            var detalleventa = await bd.Detalleventas.FindAsync(id);
            bd.Detalleventas.Remove(detalleventa!);
            await bd.SaveChangesAsync();
            return Ok();
        }
    }
}