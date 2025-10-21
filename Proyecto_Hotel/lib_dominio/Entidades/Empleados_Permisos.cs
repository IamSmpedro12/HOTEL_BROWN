using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Empleados_Permisos
    {
        public int Id { get; set; }
        public int Empleado { get; set; }
        public int Permiso { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Permiso")] public Permisos? _Permiso { get; set; }
    }
}
