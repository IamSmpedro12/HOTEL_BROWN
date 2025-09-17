using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Habitaciones_Tipos
    {
        public int Id { get; set; }
        public int Habitacion { get; set; }
        public int Tipo { get; set; }
        [ForeignKey("Habitacion")] public Habitaciones? _Habitacion { get; set; }
        [ForeignKey("Tipo")] public Tipos_Habitaciones? _Tipo { get; set; }
    }
}
