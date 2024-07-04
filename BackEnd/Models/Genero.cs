using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Persona> Personas { get; } = new List<Persona>();
}
