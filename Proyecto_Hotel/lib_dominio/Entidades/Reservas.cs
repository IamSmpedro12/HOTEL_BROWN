using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Reservas
    {
        public int Id { get; set; }
        public int Huesped { get; set; }
        public DateTime Fecha_entrada { get; set; }
        public DateTime Fecha_salida { get; set; }
        public string? Estado { get; set; }
        public DateTime Fecha_reserva { get; set; }
        [ForeignKey("Huesped")] public Huespedes? _Huesped { get; set; }
    }
}
