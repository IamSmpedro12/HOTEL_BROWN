using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Empleados_Roles
    {
        public int Id { get; set; }
        public int Empleado { get; set; }
        public int Rol { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
    }
}
