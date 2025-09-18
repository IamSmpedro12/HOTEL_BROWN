using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ServiciosAplicacion : IServiciosAplicacion
    {
        private IConexion? IConexion = null;

        public ServiciosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Servicios? Guardar(Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información del servicio");

            if (entidad.Id != 0)
                throw new Exception("El servicio ya existe");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("El nombre del servicio es obligatorio");

            if (entidad.Precio <= 0)
                throw new Exception("El precio del servicio debe ser mayor que cero");

            this.IConexion!.Servicios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Servicios? Modificar(Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información del servicio");

            if (entidad.Id == 0)
                throw new Exception("El servicio no existe");

            if (string.IsNullOrWhiteSpace(entidad.Nombre))
                throw new Exception("El nombre del servicio es obligatorio");

            if (entidad.Precio <= 0)
                throw new Exception("El precio del servicio debe ser mayor que cero");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Servicios? Borrar(Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información del servicio");

            if (entidad.Id == 0)
                throw new Exception("El servicio no existe");

            this.IConexion!.Servicios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Servicios> Listar()
        {
            return this.IConexion!.Servicios!.Take(20).ToList();
        }
    }
}
