using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Habitaciones_Tipos
    {
        public int id { get; set; }
        public int id_habitacion { get; set; }
        public int id_tipo { get; set; }
        [ForeignKey("id_habitacion")] public Habitaciones? _id_habitacion { get; set; }
        [ForeignKey("id_tipo")] public Tipos_Habitaciones? _id_tipo { get; set; }
    }
}
