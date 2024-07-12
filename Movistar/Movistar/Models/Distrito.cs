using System;
using System.Collections.Generic;

namespace Movistar.Models;

public partial class Distrito
{
    public int CodDis { get; set; }

    public string NombreEs { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
