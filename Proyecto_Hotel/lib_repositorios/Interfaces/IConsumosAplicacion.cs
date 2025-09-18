using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IConsumosAplicacion
    {
        void Configurar(string StringConexion);
        List<Consumos> Listar();
        Consumos? Guardar(Consumos? entidad);
        Consumos? Modificar(Consumos? entidad);
        Consumos? Borrar(Consumos? entidad);
    }
}
