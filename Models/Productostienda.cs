using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Productostienda
{
    public int Id { get; set; }

    public short IdTienda { get; set; }

    public int IdProducto { get; set; }

    public virtual Productos IdProductoNavigation { get; set; } = null!;

    public virtual Tiendas IdTiendaNavigation { get; set; } = null!;
}
