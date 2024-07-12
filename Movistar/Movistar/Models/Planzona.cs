using System;
using System.Collections.Generic;

namespace Movistar.Models;

public partial class Planzona
{
    public string? Estado { get; set; }

    public string? Duracion { get; set; }

    public string NombrePlan { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
