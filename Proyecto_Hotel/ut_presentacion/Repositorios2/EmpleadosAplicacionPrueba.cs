using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ut_presentacion.Nucleo;

namespace Pruebas
{
    [TestClass]
    public class EmpleadosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private IEmpleadosAplicacion? app;
        private Empleados? entidad;

        public EmpleadosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
            app = new EmpleadosAplicacion(iConexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, NoPermitirEmailDuplicado());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        private bool Guardar()
        {
            entidad = new Empleados()
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                Email = $"juan{Guid.NewGuid()}@correo.com", // para evitar colisión
                Telefono = "123456789",
                Cargo = "Recepcionista",
                Fecha_ingreso = DateTime.Now
            };

            entidad = app!.Guardar(entidad);
            return entidad != null && entidad.Id != 0;
        }

        private bool NoPermitirEmailDuplicado()
        {
            try
            {
                var duplicado = new Empleados()
                {
                    Nombre = "Pedro",
                    Apellido = "López",
                    Email = entidad!.Email, // mismo email
                    Telefono = "987654321",
                    Cargo = "Administrador",
                    Fecha_ingreso = DateTime.Now
                };

                app!.Guardar(duplicado);
                return false; // si pasa, la validación falló
            }
            catch (Exception ex)
            {
                return ex.Message.Contains("email");
            }
        }

        private bool Modificar()
        {
            if (entidad == null) return false;

            entidad.Nombre = "Juan Carlos";
            var modificado = app!.Modificar(entidad);

            return modificado != null && modificado.Nombre == "Juan Carlos";
        }

        private bool Listar()
        {
            var lista = app!.Listar();
            return lista != null && lista.Count > 0 && lista.Any(e => e.Id == entidad!.Id);
        }

        private bool Borrar()
        {
            if (entidad == null) return false;

            var borrado = app!.Borrar(entidad);
            return borrado != null;
        }
    }
}
