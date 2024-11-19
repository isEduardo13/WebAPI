using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Dtos;


namespace WebAPI.Controllers
{

    
    [Route("productos")]
    public class ProductosController : ControllerBase
    {
        private readonly Jq4bContext bd;
        private readonly IMapper mapper;

        public ProductosController (Jq4bContext bd, IMapper mapper){
            this.bd = bd;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id){
            var producto = await bd.Productos.FindAsync(id);
            return Ok(mapper.Map<ProductoDTO>(producto));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos(){
            var productos = await bd.Productos.ToListAsync();
            return Ok(mapper.Map<List<ProductoDTO>>(productos));
        }
        [HttpPost]
        public async Task<IActionResult> PostProducto(ProductoCreateDTO producto){
           Productos p = new Productos{
               NombreProducto = producto.NombreProducto,
               Stock = producto.Stock,
               Precio = producto.Precio,
               IdCategoria = producto.IdCategoria
           };
              await bd.Productos.AddAsync(p);
                await bd.SaveChangesAsync();
                return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutProducto([FromQuery]int id,[FromBody]ProductoCreateDTO producto){
            Productos p = new Productos{
                Id = id,
                NombreProducto = producto.NombreProducto,
                Stock = producto.Stock,
                Precio = producto.Precio,
                IdCategoria = producto.IdCategoria
            };
            bd.Productos.Update(p);
            await bd.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id){
            var producto = await bd.Productos.FindAsync(id);
            bd.Productos.Remove(producto!);
            await bd.SaveChangesAsync();
            return Ok();


    }


}
}