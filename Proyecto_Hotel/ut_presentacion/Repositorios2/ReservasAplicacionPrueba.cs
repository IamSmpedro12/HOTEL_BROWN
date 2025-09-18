using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class ReservasAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IReservasAplicacion? app;
        private Reservas? entidad;

        public ReservasAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new ReservasAplicacion(iConexion);
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
            entidad = new Reservas()
            {
                Huesped = 1, // FK existente en BD
                Fecha_entrada = DateTime.Now.AddDays(1),
                Fecha_salida = DateTime.Now.AddDays(3),
                Estado = null // debe quedar en "Pendiente" por defecto
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0 && entidad.Estado == "Pendiente";
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Estado = "Confirmada";
            entidad.Fecha_salida = entidad.Fecha_entrada.AddDays(5);

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Estado == "Confirmada";
        }

        private bool Listar()
        {
            var lista = app!.Listar();
            return lista != null && lista.Count > 0;
        }

        private bool Borrar()
        {
            if (entidad == null) return false;

            // Forzamos el estado a "Pendiente" para poder borrarla
            entidad.Estado = "Pendiente";
            var resultado = app!.Borrar(entidad);

            return resultado != null;
        }
    }
}
