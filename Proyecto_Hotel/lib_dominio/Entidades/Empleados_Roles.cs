using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Empleados_Roles
    {
        public int id { get; set; }
        public int id_empleado { get; set; }
        public int id_rol { get; set; }
        [ForeignKey("id_empleado")] public Empleados? _id_empleado { get; set; }
        [ForeignKey("id_rol")] public Roles? _id_rol { get; set; }
    }
}
