using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ReservasAplicacion : IReservasAplicacion
    {
        private IConexion? IConexion = null;

        public ReservasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Reservas? Guardar(Reservas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información de la reserva");

            if (entidad.Id != 0)
                throw new Exception("La reserva ya existe");

            if (entidad.Fecha_entrada >= entidad.Fecha_salida)
                throw new Exception("La fecha de entrada debe ser menor que la de salida");

            if (string.IsNullOrEmpty(entidad.Estado))
                entidad.Estado = "Pendiente";

            entidad.Fecha_reserva = DateTime.Now;

            this.IConexion!.Reservas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reservas? Modificar(Reservas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información de la reserva");

            if (entidad.Id == 0)
                throw new Exception("La reserva no existe");

            if (entidad.Fecha_entrada >= entidad.Fecha_salida)
                throw new Exception("La fecha de entrada debe ser menor que la de salida");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reservas? Borrar(Reservas? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información de la reserva");

            if (entidad.Id == 0)
                throw new Exception("La reserva no existe");

            if (entidad.Estado == "Confirmada")
                throw new Exception("No se puede borrar una reserva confirmada");

            this.IConexion!.Reservas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Reservas> Listar()
        {
            return this.IConexion!.Reservas!
                .OrderByDescending(r => r.Fecha_reserva)
                .Take(20)
                .ToList();
        }
    }
}
