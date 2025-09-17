using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Huespedes? Huespedes()
        {
            var entidad = new Huespedes();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Apellido = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Email = "prueba@hotel.com";
            entidad.Telefono = "3001234567";
            entidad.Documento = "123456789";
            entidad.Nacionalidad = "Colombia";
            entidad.Fecha_nacimiento = new DateTime(1990, 1, 1);
            return entidad;
        }
        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Apellido = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Email = "empleado@hotel.com";
            entidad.Telefono = "3007654321";
            entidad.Cargo = "Gerente";
            entidad.Fecha_ingreso = new DateTime(2020, 5, 15);
            return entidad;
        }

        public static Roles? Roles()
        {
            var entidad = new Roles();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Rol de prueba";
            return entidad;
        }

        public static Empleados_Roles? Empleados_Roles()
        {
            var entidad = new Empleados_Roles();
            entidad.Empleado = 1;
            entidad.Rol = 1;
            return entidad;
        }

        public static Habitaciones? Habitaciones()
        {
            var entidad = new Habitaciones();
            entidad.Numero = "101";
            entidad.Piso = 1;
            entidad.Tipo = "Doble";
            entidad.Capacidad = 2;
            entidad.Precio_noche = 150.50m;
            entidad.Estado = "Disponible";
            return entidad;
        }

        public static Tipos_Habitaciones? Tipos_Habitaciones()
        {
            var entidad = new Tipos_Habitaciones();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Tipo de habitación de prueba";
            entidad.Precio_base = 100.00m;
            return entidad;
        }

        public static Habitaciones_Tipos? Habitaciones_Tipos()
        {
            var entidad = new Habitaciones_Tipos();
            entidad.Habitacion = 1;
            entidad.Tipo = 1;
            return entidad;
        }

        public static Reservas? Reservas()
        {
            var entidad = new Reservas();
            entidad.Huesped = 1;
            entidad.Fecha_entrada = new DateTime(2025, 10, 20);
            entidad.Fecha_salida = new DateTime(2025, 10, 25);
            entidad.Estado = "Confirmada";
            entidad.Fecha_reserva = DateTime.Now;
            return entidad;
        }

        public static Detalles_Reservas? Detalles_Reservas()
        {
            var entidad = new Detalles_Reservas();
            entidad.Reserva = 1;
            entidad.Habitacion = 1;
            entidad.Precio_noche = 150.50m;
            entidad.Noches = 5;
            return entidad;
        }

        public static Servicios? Servicios()
        {
            var entidad = new Servicios();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Servicio de prueba";
            entidad.Precio = 25.00m;
            return entidad;
        }

        public static Reservas_Servicios? Reservas_Servicios()
        {
            var entidad = new Reservas_Servicios();
            entidad.Reserva = 1;
            entidad.Servicio = 1;
            entidad.Cantidad = 2;
            return entidad;
        }

        public static Facturas? Facturas()
        {
            var entidad = new Facturas();
            entidad.Reserva = 1;
            entidad.Fecha_emision = DateTime.Now;
            entidad.Total = 802.50m;
            entidad.Metodo_pago = "Tarjeta de crédito";
            return entidad;
        }

        public static Mantenimientos? Mantenimientos()
        {
            var entidad = new Mantenimientos();
            entidad.Habitacion = 1;
            entidad.Descripcion = "Mantenimiento de prueba";
            entidad.Fecha = DateTime.Now;
            entidad.Costo = 50.00m;
            return entidad;
        }

        public static Proveedores? Proveedores()
        {
            var entidad = new Proveedores();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Contacto = "Contacto de prueba";
            entidad.Telefono = "3009876543";
            entidad.Email = "proveedor@ejemplo.com";
            return entidad;
        }

        public static Productos? Productos()
        {
            var entidad = new Productos();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Producto de prueba";
            entidad.Stock = 50;
            entidad.Precio = 5.50m;
            entidad.Proveedor = 1;
            return entidad;
        }

        public static Consumos? Consumos()
        {
            var entidad = new Consumos();
            entidad.Cantidad = 3;
            entidad.Fecha = DateTime.Now;
            entidad.Producto = 1;
            entidad.Reserva = 1;
            return entidad;
        }
    }
}

