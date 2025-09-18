using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class DetallesReservasAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IDetallesReservasAplicacion? app;
        private Detalles_Reservas? entidad;

        public DetallesReservasAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new DetallesReservasAplicacion(iConexion);
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
            entidad = new Detalles_Reservas()
            {
                Reserva = 1,           // Debe existir una Reserva con Id=1
                Habitacion = 1,        // Debe existir una Habitación con Id=1
                Precio_noche = 120000, // Valor válido
                Noches = 2             // Valor válido
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Noches = 5;
            entidad.Precio_noche = 150000;

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Noches == 5;
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
