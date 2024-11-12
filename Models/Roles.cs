using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Roles
{
    public sbyte Id { get; set; }

    public string Rol { get; set; } = null!;

    public virtual ICollection<Encargadotienda> Encargadotienda { get; set; } = new List<Encargadotienda>();
}
