using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categorias, CategoriaDTO>();
            CreateMap<CategoriaCreateDTO, Categorias>();
            CreateMap<Productos, ProductoDTO>();
            CreateMap<CategoriaCreateDTO, Productos>();
            CreateMap<Clientes, ClienteDTO>();
            CreateMap<ClienteCreateDTO, Clientes>();
            CreateMap<Detalleventas, DetalleVentaDTO>();
            CreateMap<DetalleVentaCreateDTO, Detalleventas>();
            CreateMap<Ventas, VentaDTO>();
            CreateMap<VentaCreateDTO, Ventas>();
            CreateMap<Clientes, ClienteDTO>();
            CreateMap<ClienteCreateDTO, Clientes>();
            CreateMap<Roles, RolDTO>();
            CreateMap<RolCreateDTO, Roles>();
            CreateMap<Encargadotienda, EncargadoTiendaDTO>();
            CreateMap<EncargadoTiendaCreateDTO, Encargadotienda>();
            CreateMap<Tiendas, TiendaDTO>();
            CreateMap<TiendaCreateDTO, Tiendas>();
            CreateMap<Productostienda, ProductosTiendaDTO>();
            CreateMap<ProductosTiendaCreateDTO, Productostienda>();
        }


    }
}