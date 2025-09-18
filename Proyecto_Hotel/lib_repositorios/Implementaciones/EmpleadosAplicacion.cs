using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion? IConexion = null;

        public EmpleadosAplicacion(IConexion iConexion) => this.IConexion = iConexion;
        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Empleados? Guardar(Empleados? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");

            if (this.IConexion!.Empleados!.Any(e => e.Email == entidad.Email))
                throw new Exception("El email ya está registrado");

            this.IConexion.Empleados.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados? Modificar(Empleados? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Empleado no existe");

            if (this.IConexion!.Empleados!.Any(e => e.Email == entidad.Email && e.Id != entidad.Id))
                throw new Exception("El email ya está registrado por otro empleado");

            var entry = this.IConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Empleados? Borrar(Empleados? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No se puede borrar");

            this.IConexion!.Empleados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Listar() => this.IConexion!.Empleados!.Take(20).ToList();
    }
}