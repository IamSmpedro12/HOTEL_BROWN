using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class EmpleadosRolesAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IEmpleadosRolesAplicacion? app;
        private Empleados_Roles? entidad;

        public EmpleadosRolesAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new EmpleadosRolesAplicacion(iConexion);
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
 
            entidad = new Empleados_Roles()
            {
                Empleado = 4, // FK existente
                Rol = 2       // FK existente
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            // cambiar el rol por otro existente
            entidad.Rol = 2; //  Usa un Rol válido en tu BD
            var resultado = app!.Modificar(entidad);

            return resultado != null && resultado.Rol == 2;
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
