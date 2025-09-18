using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IDetalles_ReservasAplicacion
    {
        void Configurar(string StringConexion);
        List<Detalles_Reservas> Listar();
        Detalles_Reservas? Guardar(Detalles_Reservas? entidad);
        Detalles_Reservas? Modificar(Detalles_Reservas? entidad);
        Detalles_Reservas? Borrar(Detalles_Reservas? entidad);
    }
}
