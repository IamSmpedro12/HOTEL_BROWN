using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class DetallesReservasAplicacion : IDetallesReservasAplicacion
    {
        private IConexion? IConexion = null;

        public DetallesReservasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Detalles_Reservas? Guardar(Detalles_Reservas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información del detalle de reserva");

            if (entidad.Id != 0)
                throw new Exception("El detalle ya existe");

            if (entidad.Noches <= 0)
                throw new Exception("El número de noches debe ser mayor que cero");

            if (entidad.Precio_noche <= 0)
                throw new Exception("El precio por noche debe ser mayor que cero");

            this.IConexion!.Detalles_Reservas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Detalles_Reservas? Modificar(Detalles_Reservas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información del detalle de reserva");

            if (entidad.Id == 0)
                throw new Exception("El detalle no existe");

            if (entidad.Noches <= 0)
                throw new Exception("El número de noches debe ser mayor que cero");

            if (entidad.Precio_noche <= 0)
                throw new Exception("El precio por noche debe ser mayor que cero");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Detalles_Reservas? Borrar(Detalles_Reservas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información del detalle de reserva");

            if (entidad.Id == 0)
                throw new Exception("El detalle no existe");

            this.IConexion!.Detalles_Reservas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Detalles_Reservas> Listar()
        {
            return this.IConexion!.Detalles_Reservas!
                .Include(d => d._Habitacion) //  navegación real
                .Include(d => d._Reserva)    //  navegación real
                .Take(20)
                .ToList();
        }
    }
}
