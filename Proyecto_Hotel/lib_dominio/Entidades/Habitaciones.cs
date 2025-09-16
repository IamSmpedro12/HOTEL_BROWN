namespace lib_dominio.Entidades
{
    public class Habitaciones
    {
        public int Id { get; set; }
        public string? Numero { get; set; }
        public int Piso { get; set; }
        public string? Tipo { get; set; }
        public int Capacidad { get; set; }
        public decimal Precio_noche { get; set; }
        public string? Estado { get; set; }
    }
}
