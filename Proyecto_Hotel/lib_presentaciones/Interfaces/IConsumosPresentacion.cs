using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IConsumosPresentacion
    {
        Task<List<Consumos>> Listar();
        Task<Consumos?> Guardar(Consumos? entidad);
        Task<Consumos?> Modificar(Consumos? entidad);
        Task<Consumos?> Borrar(Consumos? entidad);
    }
}