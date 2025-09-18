using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class HabitacionesTiposAplicacion : IHabitacionesTiposAplicacion
    {
        private IConexion? IConexion = null;

        public HabitacionesTiposAplicacion(IConexion iConexion) => this.IConexion = iConexion;
        public void Configurar(string StringConexion) => this.IConexion!.StringConexion = StringConexion;

        public Habitaciones_Tipos? Guardar(Habitaciones_Tipos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");

            if (this.IConexion!.Habitaciones_Tipos!
                .Any(ht => ht.Habitacion == entidad.Habitacion && ht.Tipo == entidad.Tipo))
                throw new Exception("La habitación ya tiene este tipo asociado");

            this.IConexion.Habitaciones_Tipos.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Habitaciones_Tipos? Modificar(Habitaciones_Tipos? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No existe la relación");

            if (this.IConexion!.Habitaciones_Tipos!
                .Any(ht => ht.Habitacion == entidad.Habitacion && ht.Tipo == entidad.Tipo && ht.Id != entidad.Id))
                throw new Exception("La habitación ya tiene este tipo asociado");

            var entry = this.IConexion!.Entry<Habitaciones_Tipos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Habitaciones_Tipos? Borrar(Habitaciones_Tipos? entidad)
        {
            if (entidad == null || entidad.Id == 0) throw new Exception("No se puede borrar");

            this.IConexion!.Habitaciones_Tipos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Habitaciones_Tipos> Listar() => this.IConexion!.Habitaciones_Tipos!.Take(20).ToList();
    }
}