using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ConsumosAplicacion : IConsumosAplicacion
    {
        private IConexion? IConexion = null;

        public ConsumosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Consumos? Guardar(Consumos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id != 0) throw new Exception("Consumo ya existe");
            if (entidad.Cantidad <= 0) throw new Exception("Cantidad inválida");

            this.IConexion!.Consumos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Consumos? Modificar(Consumos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Consumo no encontrado");

            var entry = this.IConexion!.Entry(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Consumos? Borrar(Consumos? entidad)
        {
            if (entidad == null) throw new Exception("Falta información");
            if (entidad.Id == 0) throw new Exception("Consumo no encontrado");

            this.IConexion!.Consumos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Consumos> Listar()
        {
            return this.IConexion!.Consumos!.Take(20).ToList();
        }
    }

}
