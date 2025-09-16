CREATE DATABASE HOTEL_BROWN

GO
USE HOTEL_BROWN
GO

CREATE TABLE Huespedes (
    id_huesped INT PRIMARY KEY ,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    email VARCHAR(100),
    telefono VARCHAR(20),
    documento VARCHAR(50),
    nacionalidad VARCHAR(50),
    fecha_nacimiento DATE
);


CREATE TABLE Empleados (
    id_empleado INT PRIMARY KEY ,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    email VARCHAR(100),
    telefono VARCHAR(20),
    cargo VARCHAR(50),
    fecha_ingreso DATE
);


CREATE TABLE Roles (
    id_rol INT PRIMARY KEY ,
    nombre VARCHAR(50),
    descripcion TEXT
);


CREATE TABLE Empleados_Roles (
    id INT PRIMARY KEY ,
    id_empleado INT,
    id_rol INT,
    FOREIGN KEY (id_empleado) REFERENCES Empleados(id_empleado),
    FOREIGN KEY (id_rol) REFERENCES Roles(id_rol)
);


CREATE TABLE Habitaciones (
    id_habitacion INT PRIMARY KEY ,
    numero VARCHAR(10),
    piso INT,
    tipo VARCHAR(50),
    capacidad INT,
    precio_noche DECIMAL(10,2),
    estado VARCHAR(50)
);


CREATE TABLE Tipos_Habitaciones (
    id_tipo INT PRIMARY KEY ,
    nombre VARCHAR(50),
    descripcion TEXT,
    precio_base DECIMAL(10,2)
);


CREATE TABLE Habitaciones_Tipos (
    id INT PRIMARY KEY ,
    id_habitacion INT,
    id_tipo INT,
    FOREIGN KEY (id_habitacion) REFERENCES Habitaciones(id_habitacion),
    FOREIGN KEY (id_tipo) REFERENCES Tipos_Habitaciones(id_tipo)
);


CREATE TABLE Reservas (
    id_reserva INT PRIMARY KEY ,
    id_huesped INT,
    fecha_entrada DATE,
    fecha_salida DATE,
    estado VARCHAR(50),
    fecha_reserva DATE,
    FOREIGN KEY (id_huesped) REFERENCES Huespedes(id_huesped)
);


CREATE TABLE Detalles_Reservas (
    id_detalle INT PRIMARY KEY,
    id_reserva INT,
    id_habitacion INT,
    precio_noche DECIMAL(10),
    noches INT,
    FOREIGN KEY (id_reserva) REFERENCES Reservas(id_reserva),
    FOREIGN KEY (id_habitacion) REFERENCES Habitaciones(id_habitacion)
);


CREATE TABLE Servicios (
    id_servicio INT PRIMARY KEY ,
    nombre VARCHAR(100),
    descripcion TEXT,
    precio DECIMAL(10,2)
);


CREATE TABLE Reservas_Servicios (
    id INT PRIMARY KEY ,
    id_reserva INT,
    id_servicio INT,
    cantidad INT,
    FOREIGN KEY (id_reserva) REFERENCES Reservas(id_reserva),
    FOREIGN KEY (id_servicio) REFERENCES Servicios(id_servicio)
);


CREATE TABLE Facturas (
    id_factura INT PRIMARY KEY ,
    id_reserva INT,
    fecha_emision DATE,
    total DECIMAL(10),
    metodo_pago VARCHAR(50),
    FOREIGN KEY (id_reserva) REFERENCES Reservas(id_reserva)
);


CREATE TABLE Mantenimientos (
    id_mantenimiento INT PRIMARY KEY ,
    id_habitacion INT,
    descripcion TEXT,
    fecha DATE,
    costo DECIMAL(10),
    FOREIGN KEY (id_habitacion) REFERENCES Habitaciones(id_habitacion)
);


CREATE TABLE Proveedores (
    id_proveedor INT PRIMARY KEY ,
    nombre VARCHAR(100),
    contacto VARCHAR(100),
    telefono VARCHAR(20),
    email VARCHAR(100)
);


CREATE TABLE Productos (
    id_producto INT PRIMARY KEY ,
    nombre VARCHAR(100),
    descripcion TEXT,
    stock INT,
    precio DECIMAL(10),
    id_proveedor INT,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id_proveedor)
);

CREATE TABLE Consumos (
    id_consumo INT PRIMARY KEY ,
    id_producto INT,
    id_reserva INT,
    cantidad INT,
    fecha DATE,
    FOREIGN KEY (id_producto) REFERENCES Productos(id_producto),
    FOREIGN KEY (id_reserva) REFERENCES Reservas(id_reserva)
);


INSERT INTO Huespedes(id_huesped, nombre, apellido, email, telefono, documento, nacionalidad, fecha_nacimiento) VALUES
(1, 'Ana', 'Ramirez', 'ana.ramirez@email.com', '123456789', 'DNI123', 'Argentina', '1990-05-10'),
(2, 'Carlos', 'Lopez', 'c.lopez@email.com', '987654321', 'DNI124', 'Chile', '1985-11-02'),
(3, 'Lucia', 'Gomez', 'lucia.gomez@email.com', '564738291', 'DNI125', 'Perú', '1992-08-21'),
(4, 'Miguel', 'Torres', 'miguel.t@email.com', '321654987', 'DNI126', 'México', '1989-07-13'),
(5, 'Sofía', 'Martinez', 'sofia.m@email.com', '654987321', 'DNI127', 'Uruguay', '1995-12-25'),
(6, 'Jorge', 'Silva', 'jorge.s@email.com', '741852963', 'DNI128', 'Colombia', '1980-03-30'),
(7, 'Elena', 'Cruz', 'elena.cruz@email.com', '963258741', 'DNI129', 'Ecuador', '1988-09-05'),
(8, 'Raúl', 'Fernandez', 'raul.f@email.com', '852741963', 'DNI130', 'Venezuela', '1993-04-18'),
(9, 'Natalia', 'Vega', 'natalia.v@email.com', '789456123', 'DNI131', 'Paraguay', '1991-10-10'),
(10, 'Hugo', 'Morales', 'hugo.m@email.com', '456123789', 'DNI132', 'Bolivia', '1987-06-07');


INSERT INTO Empleados (id_empleado, nombre, apellido, email, telefono, cargo, fecha_ingreso) VALUES
(1, 'Laura', 'Pérez', 'laura.p@email.com', '123456000', 'Recepcionista', '2020-01-15'),
(2, 'Mario', 'Gonzalez', 'mario.g@email.com', '123456001', 'Limpieza', '2019-05-12'),
(3, 'Andrés', 'Molina', 'andres.m@email.com', '123456002', 'Gerente', '2018-11-01'),
(4, 'Sonia', 'Diaz', 'sonia.d@email.com', '123456003', 'Cocinera', '2021-04-18'),
(5, 'Pablo', 'Rios', 'pablo.r@email.com', '123456004', 'Botones', '2022-07-09'),
(6, 'Carmen', 'Flores', 'carmen.f@email.com', '123456005', 'Limpieza', '2020-09-27'),
(7, 'Diego', 'Martínez', 'diego.m@email.com', '123456006', 'Recepcionista', '2017-02-14'),
(8, 'Valeria', 'Sosa', 'valeria.s@email.com', '123456007', 'Camarera', '2016-08-25'),
(9, 'Tomas', 'Ortega', 'tomas.o@email.com', '123456008', 'Seguridad', '2023-03-01'),
(10, 'Isabel', 'Nuñez', 'isabel.n@email.com', '123456009', 'Cocinera', '2015-12-30');


INSERT INTO Roles (id_rol, nombre, descripcion) VALUES
(1, 'Administrador', 'Acceso completo'),
(2, 'Recepcionista', 'Gestiona reservas y check-in'),
(3, 'Limpieza', 'Encargado de limpieza de habitaciones'),
(4, 'Gerente', 'Administra el hotel'),
(5, 'Cocina', 'Encargado de la cocina'),
(6, 'Seguridad', 'Vigilancia del hotel'),
(7, 'Mantenimiento', 'Mantenimiento general'),
(8, 'Botones', 'Asistente de maletas'),
(9, 'Camarera', 'Servicio a la habitación'),
(10, 'Contador', 'Gestión financiera');


INSERT INTO Empleados_Roles (id, id_empleado, id_rol) VALUES
(1, 1, 2),
(2, 2, 3),
(3, 3, 4),
(4, 4, 5),
(5, 5, 8),
(6, 6, 3),
(7, 7, 2),
(8, 8, 9),
(9, 9, 6),
(10, 10, 5);


INSERT INTO Habitaciones(id_habitacion, numero, piso, tipo, capacidad, precio_noche, estado) VALUES
(1, '101', 1, 'Simple', 1, 50.00, 'Disponible'),
(2, '102', 1, 'Doble', 2, 80.00, 'Ocupada'),
(3, '103', 1, 'Suite', 3, 150.00, 'Disponible'),
(4, '104', 1, 'Doble', 2, 80.00, 'Limpieza'),
(5, '201', 2, 'Simple', 1, 50.00, 'Disponible'),
(6, '202', 2, 'Suite', 3, 150.00, 'Mantenimiento'),
(7, '203', 2, 'Doble', 2, 80.00, 'Disponible'),
(8, '301', 3, 'Suite', 3, 180.00, 'Ocupada'),
(9, '302', 3, 'Simple', 1, 60.00, 'Disponible'),
(10, '303', 3, 'Doble', 2, 90.00, 'Disponible');


INSERT INTO Tipos_Habitaciones (id_tipo, nombre, descripcion, precio_base) VALUES
(1, 'Simple', 'Una cama individual', 50.00),
(2, 'Doble', 'Dos camas', 80.00),
(3, 'Suite', 'Habitación de lujo', 150.00),
(4, 'Familiar', 'Capacidad para 4 personas', 120.00),
(5, 'VIP', 'Suite presidencial', 250.00),
(6, 'Estándar', 'Habitación básica', 60.00),
(7, 'Premium', 'Con vista al mar', 200.00),
(8, 'Business', 'Con escritorio y wifi', 100.00),
(9, 'Romántica', 'Decoración especial', 170.00),
(10, 'Económica', 'Más barata', 40.00);


INSERT INTO Habitaciones_Tipos (id, id_habitacion, id_tipo) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 2),
(5, 5, 1),
(6, 6, 3),
(7, 7, 2),
(8, 8, 3),
(9, 9, 1),
(10, 10, 2);


INSERT INTO Reservas (id_reserva, id_huesped, fecha_entrada, fecha_salida, estado, fecha_reserva) VALUES
(1, 1, '2025-09-01', '2025-09-05', 'Activa', '2025-08-25'),
(2, 2, '2025-09-10', '2025-09-12', 'Confirmada', '2025-08-30'),
(3, 3, '2025-09-15', '2025-09-20', 'Activa', '2025-09-01'),
(4, 4, '2025-10-01', '2025-10-05', 'Cancelada', '2025-09-10'),
(5, 5, '2025-09-20', '2025-09-23', 'Activa', '2025-09-05'),
(6, 6, '2025-09-25', '2025-09-30', 'Activa', '2025-09-10'),
(7, 7, '2025-10-02', '2025-10-04', 'Confirmada', '2025-09-15'),
(8, 8, '2025-09-18', '2025-09-22', 'Activa', '2025-09-01'),
(9, 9, '2025-09-28', '2025-10-01', 'Activa', '2025-09-14'),
(10, 10, '2025-09-19', '2025-09-20', 'Cancelada', '2025-09-10');


INSERT INTO Detalles_Reservas (id_detalle, id_reserva, id_habitacion, precio_noche, noches) VALUES
(1, 1, 1, 50.00, 4),
(2, 2, 2, 80.00, 2),
(3, 3, 3, 150.00, 5),
(4, 4, 4, 80.00, 4),
(5, 5, 5, 50.00, 3),
(6, 6, 6, 150.00, 5),
(7, 7, 7, 80.00, 2),
(8, 8, 8, 180.00, 4),
(9, 9, 9, 60.00, 3),
(10, 10, 10, 90.00, 1);


INSERT INTO Servicios (id_servicio, nombre, descripcion, precio) VALUES
(1, 'Desayuno', 'Desayuno continental', 10.00),
(2, 'Lavandería', 'Servicio de lavado de ropa', 15.00),
(3, 'Spa', 'Acceso al spa del hotel', 30.00),
(4, 'Gimnasio', 'Acceso al gimnasio', 5.00),
(5, 'WiFi Premium', 'Internet de alta velocidad', 7.00),
(6, 'Estacionamiento', 'Parqueo privado', 10.00),
(7, 'Room Service', 'Servicio a la habitación', 12.00),
(8, 'Almuerzo', 'Menú del día', 20.00),
(9, 'Cena', 'Cena a la carta', 25.00),
(10, 'Minibar', 'Productos del minibar', 18.00);


INSERT INTO Reservas_Servicios (id, id_reserva, id_servicio, cantidad) VALUES
(1, 1, 1, 2),
(2, 1, 2, 1),
(3, 2, 3, 1),
(4, 3, 4, 2),
(5, 4, 5, 1),
(6, 5, 6, 1),
(7, 6, 7, 1),
(8, 7, 8, 2),
(9, 8, 9, 1),
(10, 9, 10, 1);


INSERT INTO Facturas(id_factura, id_reserva, fecha_emision, total, metodo_pago) VALUES
(1, 1, '2025-09-05', 240.00, 'Tarjeta'),
(2, 2, '2025-09-12', 170.00, 'Efectivo'),
(3, 3, '2025-09-20', 750.00, 'Transferencia'),
(4, 4, '2025-10-05', 320.00, 'Tarjeta'),
(5, 5, '2025-09-23', 150.00, 'Efectivo'),
(6, 6, '2025-09-30', 400.00, 'Tarjeta'),
(7, 7, '2025-10-04', 160.00, 'Transferencia'),
(8, 8, '2025-09-22', 720.00, 'Tarjeta'),
(9, 9, '2025-10-01', 180.00, 'Efectivo'),
(10, 10, '2025-09-20', 90.00, 'Efectivo');


INSERT INTO Mantenimientos (id_mantenimiento, id_habitacion, descripcion, fecha, costo) VALUES
(1, 6, 'Revisión de aire acondicionado', '2025-08-01', 50.00),
(2, 4, 'Cambio de cerradura', '2025-07-15', 30.00),
(3, 3, 'Reparación de baño', '2025-08-05', 100.00),
(4, 5, 'Pintura de paredes', '2025-07-22', 80.00),
(5, 9, 'Cambio de alfombra', '2025-08-12', 70.00),
(6, 10, 'Limpieza profunda', '2025-09-01', 40.00),
(7, 8, 'Instalación de TV', '2025-09-10', 150.00),
(8, 2, 'Revisión eléctrica', '2025-08-18', 60.00),
(9, 1, 'Plomería', '2025-07-25', 90.00),
(10, 7, 'Reparación de ventana', '2025-09-05', 55.00);


INSERT INTO Proveedores (id_proveedor, nombre, contacto, telefono, email) VALUES
(1, 'Limpio S.A.', 'Ana Pérez', '11112222', 'ana@limpio.com'),
(2, 'TecnoHotel', 'Carlos Ruiz', '22223333', 'ventas@tecnohotel.com'),
(3, 'FoodService', 'María Gómez', '33334444', 'contacto@foodservice.com'),
(4, 'DecorAR', 'Juan Torres', '44445555', 'info@decorar.com'),
(5, 'SpaZen', 'Paula Díaz', '55556666', 'atencion@spazen.com'),
(6, 'ServiClean', 'Luis Martínez', '66667777', 'lm@serviclean.com'),
(7, 'Conectados', 'Jorge Herrera', '77778888', 'jh@conectados.com'),
(8, 'MueblesPro', 'Sandra López', '88889999', 'slopez@mueblespro.com'),
(9, 'MinibarPlus', 'Carlos Sánchez', '99990000', 'carlos@minibarplus.com'),
(10, 'Uniformes SA', 'Verónica Castro', '10101010', 'ventas@uniformessa.com');


INSERT INTO Productos (id_producto, nombre, descripcion, stock, precio, id_proveedor) VALUES
(1, 'Jabón', 'Jabón líquido de baño', 100, 2.00, 1),
(2, 'Shampoo', 'Botella de shampoo', 100, 3.50, 1),
(3, 'Toalla', 'Toalla blanca grande', 50, 5.00, 1),
(4, 'Coca Cola', 'Bebida 350ml', 200, 1.50, 9),
(5, 'Cerveza', 'Lata de cerveza', 100, 2.00, 9),
(6, 'Agua Mineral', 'Botella 500ml', 300, 1.00, 9),
(7, 'Cepillo Dental', 'Kit dental', 80, 1.20, 1),
(8, 'Pan', 'Pan en porciones', 100, 0.80, 3),
(9, 'Queso', 'Queso en lonchas', 60, 2.50, 3),
(10, 'Fruta', 'Mix de frutas', 40, 3.00, 3);


INSERT INTO Consumos (id_consumo, id_producto, id_reserva, cantidad, fecha) VALUES
(1, 4, 1, 2, '2025-09-02'),
(2, 5, 1, 1, '2025-09-03'),
(3, 6, 2, 3, '2025-09-11'),
(4, 8, 3, 2, '2025-09-16'),
(5, 9, 3, 1, '2025-09-17'),
(6, 1, 4, 1, '2025-10-01'),
(7, 2, 5, 2, '2025-09-21'),
(8, 3, 6, 1, '2025-09-26'),
(9, 7, 7, 2, '2025-10-03'),
(10, 10, 8, 1, '2025-09-19');