using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class FacturasAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IFacturasAplicacion? app;
        private Facturas? entidad;

        public FacturasAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new FacturasAplicacion(iConexion);
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

            entidad = new Facturas()
            {
                Reserva = 1, // FK existente
                Fecha_emision = DateTime.Now,
                Total = 200.50m,
                Metodo_pago = "Tarjeta"
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Metodo_pago = "Efectivo";
            entidad.Total = 300.75m;
            var resultado = app!.Modificar(entidad);

            return resultado != null && resultado.Metodo_pago == "Efectivo";
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
