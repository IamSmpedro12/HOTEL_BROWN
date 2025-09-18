using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHabitacionesTiposAplicacion
    {
        void Configurar(string StringConexion);
        List<Habitaciones_Tipos> Listar();
        Habitaciones_Tipos? Guardar(Habitaciones_Tipos? entidad);
        Habitaciones_Tipos? Modificar(Habitaciones_Tipos? entidad);
        Habitaciones_Tipos? Borrar(Habitaciones_Tipos? entidad);
    }
}
