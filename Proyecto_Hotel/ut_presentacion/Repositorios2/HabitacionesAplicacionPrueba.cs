using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class HabitacionesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IHabitacionesAplicacion? app;
        private Habitaciones? entidad;

        public HabitacionesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new HabitacionesAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        private bool Guardar()
        {
            entidad = new Habitaciones()
            {
                Numero = "999",
                Piso = 10,
                Tipo = "Suite",
                Capacidad = 2,
                Precio_noche = 180000,
                Estado = "Disponible"
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Capacidad = 3;
            entidad.Estado = "Ocupada";

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Capacidad == 3 && resultado.Estado == "Ocupada";
        }

        private bool Listar()
        {
            var lista = app!.Listar();
            return lista != null && lista.Count > 0;
        }

        private bool Borrar()
        {
            if (entidad == null) return false;

            var resultado = app!.Borrar(entidad);
            return resultado != null;
        }
    }
}
