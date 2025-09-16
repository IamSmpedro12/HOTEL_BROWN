using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Detalles_Reservas
    {
        public int id_detalle { get; set; }
        public int id_reserva { get; set; }
        public int id_habitacion { get; set; }
        public decimal precio_noche { get; set; }
        public int noches { get; set; }
        [ForeignKey("id_reserva")] public Reservas? _id_reserva { get; set; }
        [ForeignKey("id_habitacion")] public Habitaciones? _id_habitacion { get; set; }
    }
}
