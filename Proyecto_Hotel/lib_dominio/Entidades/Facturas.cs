using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Facturas
    {
        public int id_factura { get; set; }
        public int id_reserva { get; set; }
        public DateTime fecha_emision { get; set; }
        public decimal total { get; set; }
        public string? metodo_pago { get; set; }
        [ForeignKey("id_reserva")] public Reservas? _id_reserva { get; set; }
    }
}
