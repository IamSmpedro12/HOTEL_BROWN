namespace lib_dominio.Entidades
{
   public class Huespedes
    {
        public int id_huesped { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }
        public string? documento { get; set; }
        public string? nacionalidad { get; set; }
        public DateTime fecha_nacimiento { get; set; }
    }
}
