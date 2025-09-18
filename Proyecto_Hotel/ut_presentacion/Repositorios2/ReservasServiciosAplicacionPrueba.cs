using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class ReservasServiciosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IReservasServiciosAplicacion? app;
        private Reservas_Servicios? entidad;

        public ReservasServiciosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new ReservasServiciosAplicacion(iConexion);
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
            entidad = new Reservas_Servicios()
            {
                Reserva = 1,  // FK: debe existir una Reserva en BD con Id=1
                Servicio = 1, // FK: debe existir un Servicio en BD con Id=1
                Cantidad = 2  // valor válido (>0)
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Cantidad = 5; // nuevo valor válido

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Cantidad == 5;
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
