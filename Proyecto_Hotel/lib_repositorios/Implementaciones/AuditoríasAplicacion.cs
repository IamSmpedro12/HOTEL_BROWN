using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class AuditoríasAplicacion : IAuditoríasAplicacion
    {
        private IConexion? IConexion = null;

        public AuditoríasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Auditorías? Guardar(Auditorías? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id != 0) throw new Exception("Auditoría ya existe");
            if (string.IsNullOrWhiteSpace(entidad.Descripcion))
                throw new Exception("Debe haber una descripción del cambio");
            if (string.IsNullOrWhiteSpace(entidad.Accion))
                throw new Exception("Debe indicar que accion fue realizada");

            this.IConexion!.Auditorías!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Auditorías? Modificar(Auditorías? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Auditoría no encontrada");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Auditorías? Borrar(Auditorías? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Auditoría no encontrada");

            this.IConexion!.Auditorías!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Auditorías> Listar()
        {
            return this.IConexion!.Auditorías!.Take(20).ToList();
        }
    }

}
