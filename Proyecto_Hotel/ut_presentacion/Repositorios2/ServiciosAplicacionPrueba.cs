using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class ServiciosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IServiciosAplicacion? app;
        private Servicios? entidad;

        public ServiciosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new ServiciosAplicacion(iConexion);
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
            entidad = new Servicios()
            {
                Nombre = "Spa_" + Guid.NewGuid().ToString("N").Substring(0, 5), 
                Descripcion = "Servicio de spa y masajes relajantes",
                Precio = 150000
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Descripcion = "Servicio de spa actualizado con tratamientos premium";
            entidad.Precio = 200000;

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Precio == 200000;
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
