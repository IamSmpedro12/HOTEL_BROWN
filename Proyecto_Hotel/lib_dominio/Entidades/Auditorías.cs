using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Auditorías
    {
        public int Id { get; set; }
        public int Empleado { get; set; }
        public string? Accion { get; set; }
        public string? Cambios { get; set; }
        public DateTime Fecha { get; set; }
        public string? Tabla { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
    }
}
