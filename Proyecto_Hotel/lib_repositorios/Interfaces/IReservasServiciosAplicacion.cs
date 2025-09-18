using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IReservasServiciosAplicacion
    {
        void Configurar(string StringConexion);
        List<Reservas_Servicios> Listar();
        Reservas_Servicios? Guardar(Reservas_Servicios? entidad);
        Reservas_Servicios? Modificar(Reservas_Servicios? entidad);
        Reservas_Servicios? Borrar(Reservas_Servicios? entidad);
    }
}
