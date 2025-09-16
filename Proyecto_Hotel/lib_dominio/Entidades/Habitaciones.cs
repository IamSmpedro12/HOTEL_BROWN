namespace lib_dominio.Entidades
{
    public class Habitaciones
    {
        public int id_habitacion { get; set; }
        public string? numero { get; set; }
        public int piso { get; set; }
        public string? tipo { get; set; }
        public int capacidad { get; set; }
        public decimal precio_noche { get; set; }
        public string? estado { get; set; }
    }
}
