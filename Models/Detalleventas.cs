using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Detalleventas
{
    public int Id { get; set; }

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public virtual Productos IdProductoNavigation { get; set; } = null!;

    public virtual Ventas IdVentaNavigation { get; set; } = null!;
}
