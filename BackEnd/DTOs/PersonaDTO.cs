namespace BackEnd.DTOs
{
    public class PersonaDTO
    {
        public int IdPersona { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? FechaNacimiento { get; set; }
        public int? GeneroId { get; set; }
        public string? NombreGenero { get; set; }
    }
}
