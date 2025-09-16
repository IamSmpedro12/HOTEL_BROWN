namespace lib_dominio.Entidades
{
   public class Huespedes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Documento { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
    }
}
