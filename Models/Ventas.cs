using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Ventas
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public int IdCliente { get; set; }

    public virtual ICollection<Detalleventas> Detalleventas { get; set; } = new List<Detalleventas>();

    public virtual Clientes IdClienteNavigation { get; set; } = null!;
}
