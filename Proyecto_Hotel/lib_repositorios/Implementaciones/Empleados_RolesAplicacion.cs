using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Empleados_RolesAplicacion : IEmpleados_RolesAplicacion
    {
        private IConexion? IConexion = null;

        public Empleados_RolesAplicacion(IConexion iConexion) => this.IConexion = iConexion;
        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Empleados_Roles? Guardar(Empleados_Roles? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");

            if (this.IConexion!.Empleados_Roles!
                .Any(er => er.Empleado == entidad.Empleado && er.Rol == entidad.Rol))
                throw new Exception("El empleado ya tiene asignado este rol");

            this.IConexion.Empleados_Roles.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados_Roles? Modificar(Empleados_Roles? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No existe el registro");

            if (this.IConexion!.Empleados_Roles!
                .Any(er => er.Empleado == entidad.Empleado && er.Rol == entidad.Rol && er.Id != entidad.Id))
                throw new Exception("El empleado ya tiene asignado este rol");

            var entry = this.IConexion!.Entry<Empleados_Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados_Roles? Borrar(Empleados_Roles? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No se puede borrar");

            this.IConexion!.Empleados_Roles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados_Roles> Listar() => this.IConexion!.Empleados_Roles!.Take(20).ToList();
    }
}