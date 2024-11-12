using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Categorias
{
    public sbyte Id { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
