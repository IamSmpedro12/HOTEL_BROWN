using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Reservas_Servicios
    {
        public int id { get; set; }
        public int id_reserva { get; set; }
        public int id_servicio { get; set; }
        public int cantidad { get; set; }
        [ForeignKey("id_reserva")] public Reservas? _id_reserva { get; set; }
        [ForeignKey("id_servicio")] public Servicios? _id_servicio { get; set; }

    }
}
