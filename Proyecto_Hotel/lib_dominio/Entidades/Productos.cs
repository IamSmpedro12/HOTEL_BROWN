using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public int Proveedor { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
    }
}
