using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class RolesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IRolesAplicacion? app;
        private Roles? entidad;

        public RolesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new RolesAplicacion(iConexion);
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
            entidad = new Roles()
            {
                Nombre = "Rol_" + Guid.NewGuid().ToString("N").Substring(0, 5),
                Descripcion = "Rol de prueba unitaria"
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Descripcion = "Rol de prueba actualizado";
            var resultado = app!.Modificar(entidad);

            return resultado != null && resultado.Descripcion == "Rol de prueba actualizado";
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
