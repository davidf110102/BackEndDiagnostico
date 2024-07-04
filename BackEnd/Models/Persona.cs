using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? GeneroId { get; set; }

    public virtual Genero? GeneroNavigation { get; set; }
}
