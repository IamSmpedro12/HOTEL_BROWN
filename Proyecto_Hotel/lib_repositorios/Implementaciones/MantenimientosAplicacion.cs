using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class MantenimientosAplicacion : IMantenimientosAplicacion
    {
        private IConexion? IConexion = null;

        public MantenimientosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Mantenimientos? Guardar(Mantenimientos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id != 0) throw new Exception("Ya existe el mantenimiento");
            if (entidad.Costo < 0) throw new Exception("Costo inválido");

            this.IConexion!.Mantenimientos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Mantenimientos? Modificar(Mantenimientos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Registro inexistente");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Mantenimientos? Borrar(Mantenimientos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Registro inexistente");

            this.IConexion!.Mantenimientos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Mantenimientos> Listar()
        {
            return this.IConexion!.Mantenimientos!.Take(20).ToList();
        }
    }
}