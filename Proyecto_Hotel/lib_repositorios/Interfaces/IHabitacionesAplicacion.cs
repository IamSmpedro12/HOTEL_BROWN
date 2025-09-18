using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHabitacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Habitaciones> Listar();
        Habitaciones? Guardar(Habitaciones? entidad);
        Habitaciones? Modificar(Habitaciones? entidad);
        Habitaciones? Borrar(Habitaciones? entidad);
    }
}
