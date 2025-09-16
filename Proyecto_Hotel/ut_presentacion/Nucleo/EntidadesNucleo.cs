using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Huespedes? Huespedes()
        {
            var entidad = new Huespedes();
            entidad.id_huesped = 1;
            entidad.nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.apellido = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.email = "prueba@hotel.com";
            entidad.telefono = "3001234567";
            entidad.documento = "123456789";
            entidad.nacionalidad = "Colombia";
            entidad.fecha_nacimiento = new DateTime(1990, 1, 1);

            return entidad;
        }

        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.id_empleado = 1;
            entidad.nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.apellido = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.email = "empleado@hotel.com";
            entidad.telefono = "3007654321";
            entidad.cargo = "Gerente";
            entidad.fecha_ingreso = new DateTime(2020, 5, 15);

            return entidad;
        }

        public static Roles? Roles()
        {
            var entidad = new Roles();
            entidad.id_rol = 1;
            entidad.nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.descripcion = "Rol de prueba";

            return entidad;
        }

        public static Empleados_Roles? Empleados_Roles()
        {
            var entidad = new Empleados_Roles();
            entidad.id = 1;
            entidad.id_empleado = 1;
            entidad.id_rol = 1;

            return entidad;
        }

        public static Habitaciones? Habitaciones()
        {
            var entidad = new Habitaciones();
            entidad.id_habitacion = 1;
            entidad.numero = "101";
            entidad.piso = 1;
            entidad.tipo = "Doble";
            entidad.capacidad = 2;
            entidad.precio_noche = 150.50m;
            entidad.estado = "Disponible";

            return entidad;
        }

        public static Tipos_Habitaciones? Tipos_Habitaciones()
        {
            var entidad = new Tipos_Habitaciones();
            entidad.id_tipo = 1;
            entidad.nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.descripcion = "Tipo de habitación de prueba";
            entidad.precio_base = 100.00m;

            return entidad;
        }

        public static Habitaciones_Tipos? Habitaciones_Tipos()
        {
            var entidad = new Habitaciones_Tipos();
            entidad.id = 1;
            entidad.id_habitacion = 1;
            entidad.id_tipo = 1;

            return entidad;
        }

        public static Reservas? Reservas()
        {
            var entidad = new Reservas();
            entidad.id_reserva = 1;
            entidad.id_huesped = 1;
            entidad.fecha_entrada = new DateTime(2025, 10, 20);
            entidad.fecha_salida = new DateTime(2025, 10, 25);
            entidad.estado = "Confirmada";
            entidad.fecha_reserva = DateTime.Now;

            return entidad;
        }

        public static Detalles_Reservas? Detalles_Reservas()
        {
            var entidad = new Detalles_Reservas();
            entidad.id_detalle = 1;
            entidad.id_reserva = 1;
            entidad.id_habitacion = 1;
            entidad.precio_noche = 150.50m;
            entidad.noches = 5;

            return entidad;
        }

        public static Servicios? Servicios()
        {
            var entidad = new Servicios();
            entidad.id_servicio = 1;
            entidad.nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.descripcion = "Servicio de prueba";
            entidad.precio = 25.00m;

            return entidad;
        }

        public static Reservas_Servicios? Reservas_Servicios()
        {
            var entidad = new Reservas_Servicios();
            entidad.id = 1;
            entidad.id_reserva = 1;
            entidad.id_servicio = 1;
            entidad.cantidad = 2;

            return entidad;
        }

        public static Facturas? Facturas()
        {
            var entidad = new Facturas();
            entidad.id_factura = 1;
            entidad.id_reserva = 1;
            entidad.fecha_emision = DateTime.Now;
            entidad.total = 802.50m;
            entidad.metodo_pago = "Tarjeta de crédito";

            return entidad;
        }

        public static Mantenimientos? Mantenimientos()
        {
            var entidad = new Mantenimientos();
            entidad.id_mantenimiento = 1;
            entidad.id_habitacion = 1;
            entidad.descripcion = "Mantenimiento de prueba";
            entidad.fecha = DateTime.Now;
            entidad.costo = 50.00m;

            return entidad;
        }

        public static Proveedores? Proveedores()
        {
            var entidad = new Proveedores();
            entidad.id_proveedor = 1;
            entidad.nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.contacto = "Contacto de prueba";
            entidad.telefono = "3009876543";
            entidad.email = "proveedor@ejemplo.com";

            return entidad;
        }

        public static Productos? Productos()
        {
            var entidad = new Productos();
            entidad.id_producto = 1;
            entidad.nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.descripcion = "Producto de prueba";
            entidad.stock = 50;
            entidad.precio = 5.50m;
            entidad.id_proveedor = 1;

            return entidad;
        }

        public static Consumos? Consumos()
        {
            var entidad = new Consumos();
            entidad.id_consumo = 1;
            entidad.id_producto = 1;
            entidad.id_reserva = 1;
            entidad.cantidad = 3;
            entidad.fecha = DateTime.Now;

            return entidad;
        }
    }
}