using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class MantenimientosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IMantenimientosAplicacion? app;
        private Mantenimientos? entidad;

        public MantenimientosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new MantenimientosAplicacion(iConexion);
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
            entidad = new Mantenimientos()
            {
                Habitacion = 1,                  // Debe existir una habitación con Id=1
                Descripcion = "Cambio de lámparas",
                Fecha = DateTime.Now,
                Costo = 200000
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Descripcion = "Cambio de aire acondicionado";
            entidad.Costo = 500000;

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Costo == 500000;
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
