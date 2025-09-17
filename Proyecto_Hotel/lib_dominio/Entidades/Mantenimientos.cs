using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Mantenimientos
    {
        public int Id { get; set; }
        public int Habitacion { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Costo { get; set; }
        [ForeignKey("Habitacion")] public Habitaciones? _Habitacion { get; set; }
    }
}
