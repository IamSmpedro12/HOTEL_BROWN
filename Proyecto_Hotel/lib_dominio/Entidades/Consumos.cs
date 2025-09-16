using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Consumos
    {
        public int id_consumo { get; set; }
        public int id_producto { get; set; }
        public int id_reserva { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("id_producto")] public Productos? _id_producto { get; set; }
        [ForeignKey("id_reserva")] public Reservas? _id_reserva { get; set; }
    }
}
