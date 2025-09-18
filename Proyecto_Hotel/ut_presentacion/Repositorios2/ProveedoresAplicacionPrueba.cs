using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class ProveedoresAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IProveedoresAplicacion? app;
        private Proveedores? entidad;

        public ProveedoresAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new ProveedoresAplicacion(iConexion);
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
            entidad = new Proveedores()
            {
                Nombre = "Proveedor Hotel ABC",
                Contacto = "Juan Pérez",
                Telefono = "3001234567",
                Email = "proveedor.abc@email.com"
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Nombre = "Proveedor Hotel XYZ";
            entidad.Telefono = "3119876543";

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Nombre == "Proveedor Hotel XYZ";
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
