using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Reservas_Servicios
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public int Servicio { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("Reserva")] public Reservas? _Reserva { get; set; }
        [ForeignKey("Servicio")] public Servicios? _Servicio { get; set; }

    }
}
