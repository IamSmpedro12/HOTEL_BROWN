using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class ProductosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IProductosAplicacion? app;
        private Productos? entidad;

        public ProductosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new ProductosAplicacion(iConexion);
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
            entidad = new Productos()
            {
                Nombre = "Shampoo Hotel",
                Descripcion = "Shampoo de cortesía para huéspedes",
                Stock = 50,
                Precio = 12000,
                Proveedor = 1 
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Stock = 100;
            entidad.Precio = 15000;

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Stock == 100;
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

