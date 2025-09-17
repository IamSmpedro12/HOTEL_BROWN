using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Detalles_Reservas
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public int Habitacion { get; set; }
        public decimal Precio_noche { get; set; }
        public int Noches { get; set; }
        [ForeignKey("Reserva")] public Reservas? _Reserva { get; set; }
        [ForeignKey("Habitacion")] public Habitaciones? _Habitacion { get; set; }
    }
}
