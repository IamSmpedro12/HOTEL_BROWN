using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public int Reserva { get; set; }
        public DateTime Fecha_emision { get; set; }
        public decimal Total { get; set; }
        public string? Metodo_pago { get; set; }
        [ForeignKey("Reserva")] public Reservas? _Reserva { get; set; }
    }
}
