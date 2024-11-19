using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Google.Protobuf.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("Categorias")]
    public class CategoriasController : Controller
    {
        private readonly Jq4bContext bd;
        private readonly IMapper mapper;
        public CategoriasController(Jq4bContext bd, IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;


        }
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await bd.Categorias.ToListAsync();
            return Ok(mapper.Map<List<CategoriaDTO>>(categorias));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById(sbyte id)
        {
            var categoria = await bd.Categorias.FindAsync(id);
            return Ok(mapper.Map<CategoriaDTO>(categoria));
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody]CategoriaCreateDTO categoria)
        {
            Categorias c = new Categorias
            {
                NombreCategoria = categoria.NombreCategoria
            };
            await bd.Categorias.AddAsync(c);
            await bd.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutCategoria( [FromQuery]sbyte Id, [FromBody]CategoriaCreateDTO categoria)
        {   Categorias c = new Categorias
            {
                Id = Id,
                NombreCategoria = categoria.NombreCategoria
            };
            bd.Categorias.Update(c);
            await bd.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(sbyte id)
        {
            var categoria = await bd.Categorias.FindAsync(id);
            bd.Categorias.Remove(categoria!);
            await bd.SaveChangesAsync();
            return Ok();
        }


    }
}