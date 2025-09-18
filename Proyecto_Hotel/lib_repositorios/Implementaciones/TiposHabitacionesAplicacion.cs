using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class TiposHabitacionesAplicacion : ITiposHabitacionesAplicacion
    {
        private IConexion? IConexion = null;

        public TiposHabitacionesAplicacion(IConexion iConexion) => this.IConexion = iConexion;
        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Tipos_Habitaciones? Guardar(Tipos_Habitaciones? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Precio_base <= 0) throw new Exception("El precio base debe ser mayor a 0");

            this.IConexion!.Tipos_Habitaciones!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Tipos_Habitaciones? Modificar(Tipos_Habitaciones? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No existe el tipo de habitación");
            if (entidad.Precio_base <= 0) throw new Exception("El precio base debe ser mayor a 0");

            var entry = this.IConexion!.Entry<Tipos_Habitaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Tipos_Habitaciones? Borrar(Tipos_Habitaciones? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No se puede borrar");

            this.IConexion!.Tipos_Habitaciones!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Tipos_Habitaciones> Listar() => this.IConexion!.Tipos_Habitaciones!.Take(20).ToList();
    }
}