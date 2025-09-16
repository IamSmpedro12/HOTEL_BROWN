using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Mantenimientos
    {
        public int id_mantenimiento { get; set; }
        public int id_habitacion { get; set; }
        public string? descripcion { get; set; }
        public DateTime fecha { get; set; }
        public decimal costo { get; set; }
        [ForeignKey("id_habitacion")] public Habitaciones? _id_habitacion { get; set; }
    }
}
