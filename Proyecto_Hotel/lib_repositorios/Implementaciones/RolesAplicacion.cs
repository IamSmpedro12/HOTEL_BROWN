using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion? IConexion = null;

        public RolesAplicacion(IConexion iConexion) => this.IConexion = iConexion;
        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Roles? Guardar(Roles? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");

            if (this.IConexion!.Roles!.Any(r => r.Nombre == entidad.Nombre))
                throw new Exception("El rol ya existe");

            this.IConexion.Roles.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Roles? Modificar(Roles? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No existe el rol");

            if (this.IConexion!.Roles!.Any(r => r.Nombre == entidad.Nombre && r.Id != entidad.Id))
                throw new Exception("El nombre del rol ya existe");

            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Roles? Borrar(Roles? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No se puede borrar");

            this.IConexion!.Roles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles> Listar() => this.IConexion!.Roles!.Take(20).ToList();
    }
}