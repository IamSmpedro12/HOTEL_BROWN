using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHuespedesAplicacion
    {
        void Configurar(string StringConexion);
        List<Huespedes> Listar();
        Huespedes? Guardar(Huespedes? entidad);
        Huespedes? Modificar(Huespedes? entidad);
        Huespedes? Borrar(Huespedes? entidad);
    }
}
