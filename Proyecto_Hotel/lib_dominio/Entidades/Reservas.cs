namespace lib_dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Reservas
    {
        public int id_reserva { get; set; }
        public int id_huesped { get; set; }
        public DateTime fecha_entrada { get; set; }
        public DateTime fecha_salida { get; set; }
        public string? estado { get; set; }
        public DateTime fecha_reserva { get; set; }
        [ForeignKey("id_huesped")] public Huespedes? _id_huesped { get; set; }
    }
}
