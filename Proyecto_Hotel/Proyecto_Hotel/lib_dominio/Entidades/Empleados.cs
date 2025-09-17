namespace lib_dominio.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }
        public DateTime Fecha_ingreso { get; set; }

    }
}