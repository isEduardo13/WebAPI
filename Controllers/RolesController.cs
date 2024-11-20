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
    
    [Route("Roles")]
    public class RolesController : Controller
    {
        private readonly Jq4bContext bd;
        private readonly IMapper mapper;

        public RolesController(Jq4bContext bd, IMapper mapper)
        {
            this.bd = bd;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById(sbyte id)
        {
            var rol = await bd.Roles.FindAsync(id);
            return Ok(mapper.Map<RolDTO>(rol));
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await bd.Roles.ToListAsync();
            return Ok(mapper.Map<List<RolDTO>>(roles));
        }

        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] RolCreateDTO rol)
        {
            Roles r = new Roles
            {
                Rol = rol.Rol
            };
            await bd.Roles.AddAsync(r);
            await bd.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutRol([FromQuery] sbyte Id, [FromBody] RolCreateDTO rol)
        {
            Roles r = new Roles
            {
                Id = Id,
                Rol = rol.Rol
            };
            bd.Roles.Update(r);
            await bd.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(sbyte id)
        {
            var rol = await bd.Roles.FindAsync(id);
            bd.Roles.Remove(rol!);
            await bd.SaveChangesAsync();
            return Ok();
        }

    }
}