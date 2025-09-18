using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ReservasServiciosAplicacion : IReservasServiciosAplicacion
    {
        private IConexion? IConexion = null;

        public ReservasServiciosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Reservas_Servicios? Guardar(Reservas_Servicios? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id != 0) throw new Exception("Ya existe el registro");
            if (entidad.Cantidad <= 0) throw new Exception("Cantidad inválida");

            this.IConexion!.Reservas_Servicios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reservas_Servicios? Modificar(Reservas_Servicios? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Registro inexistente");
            if (entidad.Cantidad <= 0) throw new Exception("Cantidad inválida");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Reservas_Servicios? Borrar(Reservas_Servicios? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Registro inexistente");

            this.IConexion!.Reservas_Servicios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Reservas_Servicios> Listar()
        {
            return this.IConexion!.Reservas_Servicios!.Take(20).ToList();
        }
    }
}
