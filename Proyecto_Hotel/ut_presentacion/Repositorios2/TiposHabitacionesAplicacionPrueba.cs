using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class TiposHabitacionesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private ITiposHabitacionesAplicacion? app;
        private Tipos_Habitaciones? entidad;

        public TiposHabitacionesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new TiposHabitacionesAplicacion(iConexion);
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
            entidad = new Tipos_Habitaciones()
            {
                Nombre = "Suite_" + Guid.NewGuid().ToString("N").Substring(0, 5),
                Descripcion = "Habitación de lujo con vista al mar",
                Precio_base = 450000
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Descripcion = "Habitación suite actualizada con jacuzzi";
            entidad.Precio_base = 500000;

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Precio_base == 500000;
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
