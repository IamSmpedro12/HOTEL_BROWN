using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class HabitacionesTiposAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IHabitacionesTiposAplicacion? app;
        private Habitaciones_Tipos? entidad;

        public HabitacionesTiposAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new HabitacionesTiposAplicacion(iConexion);
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
            entidad = new Habitaciones_Tipos()
            {
                Habitacion = 1,   // Debe existir una Habitación con Id=1
                Tipo = 2          // Debe existir un Tipo con Id=2
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            // Simulación de modificación: cambiar el tipo asociado
            entidad.Tipo = 2; // Debe existir un Tipo con Id=2 en la BD

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Tipo == 2;
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
