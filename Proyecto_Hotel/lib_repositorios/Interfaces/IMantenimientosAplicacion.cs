using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IMantenimientosAplicacion
    {
        void Configurar(string StringConexion);
        List<Mantenimientos> Listar();
        Mantenimientos? Guardar(Mantenimientos? entidad);
        Mantenimientos? Modificar(Mantenimientos? entidad);
        Mantenimientos? Borrar(Mantenimientos? entidad);
    }
}
