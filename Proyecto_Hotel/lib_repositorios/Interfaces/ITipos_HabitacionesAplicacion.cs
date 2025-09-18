using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ITipos_HabitacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Tipos_Habitaciones> Listar();
        Tipos_Habitaciones? Guardar(Tipos_Habitaciones? entidad);
        Tipos_Habitaciones? Modificar(Tipos_Habitaciones? entidad);
        Tipos_Habitaciones? Borrar(Tipos_Habitaciones? entidad);
    }
}
