using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class HuespedesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IHuespedesAplicacion? app;
        private Huespedes? entidad;

        public HuespedesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new HuespedesAplicacion(iConexion);
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
            entidad = new Huespedes()
            {
                Nombre = "Carlos",
                Apellido = "Gómez",
                Email = $"carlos{Guid.NewGuid()}@mail.com", // único para evitar duplicados
                Telefono = "3001234567",
                Documento = $"DOC{Guid.NewGuid()}", // único para evitar duplicados
                Nacionalidad = "Colombiana",
                Fecha_nacimiento = new DateTime(1990, 5, 20)
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Telefono = "3107654321";
            entidad.Nacionalidad = "Argentina";

            var resultado = app!.Modificar(entidad);
            return resultado != null && resultado.Telefono == "3107654321";
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
