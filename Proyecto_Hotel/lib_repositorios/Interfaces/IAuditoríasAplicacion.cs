using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IAuditoríasAplicacion
    {
        void Configurar(string StringConexion);
        List<Auditorías> Listar();
        Auditorías? Guardar(Auditorías? entidad);
        Auditorías? Modificar(Auditorías? entidad);
        Auditorías? Borrar(Auditorías? entidad);
    }
}
