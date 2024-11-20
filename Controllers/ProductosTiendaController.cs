using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    
    [Route("ProductosTienda")]
    public class ProductosTiendaController : Controller
    {
        private readonly Jq4bContext bd;
        private readonly IMapper mapper;
        public ProductosTiendaController(Jq4bContext bd, IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoTiendaById(int id)
        {
            var productoTienda = await bd.Productostienda.FindAsync(id);
            return Ok(mapper.Map<ProductosTiendaDTO>(productoTienda));
        }
        [HttpGet]
        public async Task<IActionResult> GetProductosTienda()
        {
            var productosTienda = await bd.Productostienda.ToListAsync();
            return Ok(mapper.Map<List<ProductosTiendaDTO>>(productosTienda));
        }
        [HttpPost]
        public async Task<IActionResult> PostProductoTienda([FromBody]ProductosTiendaCreateDTO productoTienda)
        {
            Productostienda pt = new Productostienda
            {
                IdTienda = productoTienda.IdTienda,
                IdProducto = productoTienda.IdProducto
            };
            await bd.Productostienda.AddAsync(pt);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutProductoTienda([FromQuery] int Id, [FromBody] ProductosTiendaCreateDTO productoTienda)
        {
            Productostienda pt = new Productostienda
            {
                Id = Id,
                IdTienda = productoTienda.IdTienda,
                IdProducto = productoTienda.IdProducto
            };
            bd.Productostienda.Update(pt);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoTienda(int id)
        {
            var productoTienda = await bd.Productostienda.FindAsync(id);
            bd.Productostienda.Remove(productoTienda!);
            await bd.SaveChangesAsync();
            return Ok();
        }
    }
}