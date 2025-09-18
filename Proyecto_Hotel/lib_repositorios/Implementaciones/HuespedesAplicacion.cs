using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class HuespedesAplicacion : IHuespedesAplicacion
    {
        private IConexion? IConexion = null;

        public HuespedesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Huespedes? Guardar(Huespedes? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (string.IsNullOrWhiteSpace(entidad.Email))
                throw new Exception("El email es obligatorio");

            if (this.IConexion!.Huespedes!.Any(h => h.Email == entidad.Email))
                throw new Exception("El email ya está registrado");

            if (this.IConexion!.Huespedes!.Any(h => h.Documento == entidad.Documento))
                throw new Exception("El documento ya está registrado");

            this.IConexion.Huespedes.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Huespedes? Modificar(Huespedes? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.Id == 0)
                throw new Exception("No existe el huésped");

            if (this.IConexion!.Huespedes!.Any(h => h.Email == entidad.Email && h.Id != entidad.Id))
                throw new Exception("El email ya está registrado por otro huésped");

            var entry = this.IConexion!.Entry<Huespedes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Huespedes? Borrar(Huespedes? entidad)
        {
            if (entidad == null)
                throw new Exception("Falta información");

            if (entidad.Id == 0)
                throw new Exception("No se ha guardado");

            this.IConexion!.Huespedes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Huespedes> Listar()
        {
            return this.IConexion!.Huespedes!.Take(20).ToList();
        }
    }
}
