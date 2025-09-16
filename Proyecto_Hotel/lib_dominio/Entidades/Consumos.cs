using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Consumos
    {
        public int Id { get; set; }
        public int Producto { get; set; }
        public int Reserva { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
        [ForeignKey("Reserva")] public Reservas? _Reserva { get; set; }
    }
}
