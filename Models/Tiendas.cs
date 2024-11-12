using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Tiendas
{
    public short Id { get; set; }

    public string NombreTienda { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public string Telefono { get; set; } = null!;

    public short IdEncargado { get; set; }

    public virtual Encargadotienda IdEncargadoNavigation { get; set; } = null!;

    public virtual ICollection<Productostienda> Productostienda { get; set; } = new List<Productostienda>();
}
