using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEmpleados_RolesAplicacion
    {
        void Configurar(string StringConexion);
        List<Empleados_Roles> Listar();
        Empleados_Roles? Guardar(Empleados_Roles? entidad);
        Empleados_Roles? Modificar(Empleados_Roles? entidad);
        Empleados_Roles? Borrar(Empleados_Roles? entidad);
    }
}
