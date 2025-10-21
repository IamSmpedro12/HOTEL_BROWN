using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion? IConexion = null;

        public PermisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Permisos? Guardar(Permisos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id != 0) throw new Exception("Permiso ya existe");
            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("El nombre del permiso es necesario para su identificación");

            this.IConexion!.Permisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Permisos? Modificar(Permisos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Permiso no encontrado");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Permisos? Borrar(Permisos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Permiso no encontrado");

            this.IConexion!.Permisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Permisos> Listar()
        {
            return this.IConexion!.Permisos!.Take(20).ToList();
        }
    }

}
