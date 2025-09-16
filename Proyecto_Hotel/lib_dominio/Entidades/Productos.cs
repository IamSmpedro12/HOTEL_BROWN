using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Productos
    {
        public int id_producto { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
        public int id_proveedor { get; set; }
        [ForeignKey("id_proveedor")] public Proveedores? _id_proveedor { get; set; }
    }
}
