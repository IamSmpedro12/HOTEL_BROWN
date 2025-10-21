using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEmpleadosPermisosAplicacion
    {
        void Configurar(string StringConexion);
        List<Empleados_Permisos> Listar();
        Empleados_Permisos? Guardar(Empleados_Permisos? entidad);
        Empleados_Permisos? Modificar(Empleados_Permisos? entidad);
        Empleados_Permisos? Borrar(Empleados_Permisos? entidad);
    }
}
