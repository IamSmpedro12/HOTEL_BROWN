namespace lib_dominio.Entidades
{
    public class Empleados
    {
        public int id_empleado { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }
        public string? cargo { get; set; }
        public DateTime fecha_ingreso { get; set; }

    }
}