using System;
using System.Collections.Generic;

namespace Movistar.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Estado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Telefono { get; set; }

    public string? NombreEs { get; set; }

    public virtual Planzona? EstadoNavigation { get; set; }

    public virtual Distrito? NombreEsNavigation { get; set; }
}
