using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EmpleadosPermisosAplicacion : IEmpleadosPermisosAplicacion
    {
        private IConexion? IConexion = null;

        public EmpleadosPermisosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Empleados_Permisos? Guardar(Empleados_Permisos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id != 0) throw new Exception("La relación ya existe");

            this.IConexion!.Empleados_Permisos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados_Permisos? Modificar(Empleados_Permisos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Relación no encontrada");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados_Permisos? Borrar(Empleados_Permisos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Relación no encontrada");

            this.IConexion!.Empleados_Permisos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados_Permisos> Listar()
        {
            return this.IConexion!.Empleados_Permisos!.Take(20).ToList();
        }
    }

}
