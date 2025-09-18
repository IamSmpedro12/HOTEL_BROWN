using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class HabitacionesAplicacion : IHabitacionesAplicacion
    {
        private IConexion? IConexion = null;

        public HabitacionesAplicacion(IConexion iConexion) => this.IConexion = iConexion;
        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Habitaciones? Guardar(Habitaciones? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Capacidad <= 0) throw new Exception("La capacidad debe ser mayor a 0");

            if (this.IConexion!.Habitaciones!
                .Any(h => h.Numero == entidad.Numero && h.Piso == entidad.Piso))
                throw new Exception("Ya existe una habitación con ese número en el mismo piso");

            this.IConexion.Habitaciones.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Habitaciones? Modificar(Habitaciones? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No existe la habitación");
            if (entidad.Capacidad <= 0) throw new Exception("La capacidad debe ser mayor a 0");

            if (this.IConexion!.Habitaciones!
                .Any(h => h.Numero == entidad.Numero && h.Piso == entidad.Piso && h.Id != entidad.Id))
                throw new Exception("Ya existe otra habitación con ese número en el mismo piso");

            var entry = this.IConexion!.Entry<Habitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Habitaciones? Borrar(Habitaciones? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No se puede borrar");

            this.IConexion!.Habitaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Habitaciones> Listar() => this.IConexion!.Habitaciones!.Take(20).ToList();
    }
}