using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Productos
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public int Stock { get; set; }

    public decimal Precio { get; set; }

    public sbyte IdCategoria { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<Detalleventas> Detalleventas { get; set; } = new List<Detalleventas>();

    public virtual Categorias IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Productostienda> Productostienda { get; set; } = new List<Productostienda>();
}
