using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion? IConexion = null;

        public ProductosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Productos? Guardar(Productos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id != 0) throw new Exception("Producto ya existe");
            if (entidad.Stock < 0) throw new Exception("Stock inválido");
            if (entidad.Precio < 0) throw new Exception("Precio inválido");

            this.IConexion!.Productos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Productos? Modificar(Productos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Producto no encontrado");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Productos? Borrar(Productos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Producto no encontrado");

            this.IConexion!.Productos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Productos> Listar()
        {
            return this.IConexion!.Productos!.Take(20).ToList();
        }
    }

}
