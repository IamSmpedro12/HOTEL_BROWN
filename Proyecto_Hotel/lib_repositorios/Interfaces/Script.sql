CREATE DATABASE HOTEL_BROWN

GO
USE HOTEL_BROWN
GO

CREATE TABLE Huespedes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    Documento VARCHAR(50),
    Nacionalidad VARCHAR(50),
    Fecha_nacimiento DATE
);


CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    Cargo VARCHAR(50),
    Fecha_ingreso DATE
);


CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50),
    Descripcion TEXT
);


CREATE TABLE Empleados_Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Empleado INT,
    Rol INT,
    FOREIGN KEY (Empleado) REFERENCES Empleados(Id),
    FOREIGN KEY (Rol) REFERENCES Roles(Id)
);


CREATE TABLE Habitaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Numero VARCHAR(10),
    Piso INT,
    Tipo VARCHAR(50),
    Capacidad INT,
    Precio_noche DECIMAL(10,2),
    Estado VARCHAR(50)
);


CREATE TABLE Tipos_Habitaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50),
    Descripcion TEXT,
    Precio_base DECIMAL(10,2)
);


CREATE TABLE Habitaciones_Tipos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Habitacion INT,
    Tipo INT,
    FOREIGN KEY (Habitacion) REFERENCES Habitaciones(Id),
    FOREIGN KEY (Tipo) REFERENCES Tipos_Habitaciones(Id)
);


CREATE TABLE Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Huesped INT,
    Fecha_entrada DATE,
    Fecha_salida DATE,
    Estado VARCHAR(50),
    Fecha_reserva DATE,
    FOREIGN KEY (Huesped) REFERENCES Huespedes(Id)
);


CREATE TABLE Detalles_Reservas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Reserva INT,
    Habitacion INT,
    Precio_noche DECIMAL(10),
    Noches INT,
    FOREIGN KEY (Reserva) REFERENCES Reservas(Id),
    FOREIGN KEY (Habitacion) REFERENCES Habitaciones(Id)
);


CREATE TABLE Servicios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Precio DECIMAL(10,2)
);


CREATE TABLE Reservas_Servicios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Reserva INT,
    Servicio INT,
    Cantidad INT,
    FOREIGN KEY (Reserva) REFERENCES Reservas(Id),
    FOREIGN KEY (Servicio) REFERENCES Servicios(Id)
);


CREATE TABLE Facturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Reserva INT,
    Fecha_emision DATE,
    Total DECIMAL(10),
    Metodo_pago VARCHAR(50),
    FOREIGN KEY (Reserva) REFERENCES Reservas(Id)
);


CREATE TABLE Mantenimientos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Habitacion INT,
    Descripcion TEXT,
    Fecha DATE,
    Costo DECIMAL(10),
    FOREIGN KEY (Habitacion) REFERENCES Habitaciones(Id)
);


CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Contacto VARCHAR(100),
    Telefono VARCHAR(20),
    Email VARCHAR(100)
);


CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100),
    Descripcion TEXT,
    Stock INT,
    Precio DECIMAL(10),
    Proveedor INT,
    FOREIGN KEY (Proveedor) REFERENCES Proveedores(Id)
);

CREATE TABLE Consumos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Producto INT,
    Reserva INT,
    Cantidad INT,
    Fecha DATE,
    FOREIGN KEY (Producto) REFERENCES Productos(Id),
    FOREIGN KEY (Reserva) REFERENCES Reservas(Id)
);


INSERT INTO Huespedes(Nombre, Apellido, Email, Telefono, Documento, Nacionalidad, Fecha_nacimiento) VALUES
('Ana', 'Ramirez', 'ana.ramirez@email.com', '123456789', 'DNI123', 'Argentina', '1990-05-10'),
('Carlos', 'Lopez', 'c.lopez@email.com', '987654321', 'DNI124', 'Chile', '1985-11-02'),
('Lucia', 'Gomez', 'lucia.gomez@email.com', '564738291', 'DNI125', 'Perú', '1992-08-21'),
('Miguel', 'Torres', 'miguel.t@email.com', '321654987', 'DNI126', 'México', '1989-07-13'),
('Sofía', 'Martinez', 'sofia.m@email.com', '654987321', 'DNI127', 'Uruguay', '1995-12-25'),
('Jorge', 'Silva', 'jorge.s@email.com', '741852963', 'DNI128', 'Colombia', '1980-03-30'),
('Elena', 'Cruz', 'elena.cruz@email.com', '963258741', 'DNI129', 'Ecuador', '1988-09-05'),
('Raúl', 'Fernandez', 'raul.f@email.com', '852741963', 'DNI130', 'Venezuela', '1993-04-18'),
('Natalia', 'Vega', 'natalia.v@email.com', '789456123', 'DNI131', 'Paraguay', '1991-10-10'),
('Hugo', 'Morales', 'hugo.m@email.com', '456123789', 'DNI132', 'Bolivia', '1987-06-07');


INSERT INTO Empleados (Nombre, Apellido, Email, Telefono, Cargo, Fecha_ingreso) VALUES
('Laura', 'Pérez', 'laura.p@email.com', '123456000', 'Recepcionista', '2020-01-15'),
('Mario', 'Gonzalez', 'mario.g@email.com', '123456001', 'Limpieza', '2019-05-12'),
('Andrés', 'Molina', 'andres.m@email.com', '123456002', 'Gerente', '2018-11-01'),
('Sonia', 'Diaz', 'sonia.d@email.com', '123456003', 'Cocinera', '2021-04-18'),
('Pablo', 'Rios', 'pablo.r@email.com', '123456004', 'Botones', '2022-07-09'),
('Carmen', 'Flores', 'carmen.f@email.com', '123456005', 'Limpieza', '2020-09-27'),
('Diego', 'Martínez', 'diego.m@email.com', '123456006', 'Recepcionista', '2017-02-14'),
('Valeria', 'Sosa', 'valeria.s@email.com', '123456007', 'Camarera', '2016-08-25'),
('Tomas', 'Ortega', 'tomas.o@email.com', '123456008', 'Seguridad', '2023-03-01'),
('Isabel', 'Nuñez', 'isabel.n@email.com', '123456009', 'Cocinera', '2015-12-30');


INSERT INTO Roles (Nombre, Descripcion) VALUES
('Administrador', 'Acceso completo'),
('Recepcionista', 'Gestiona reservas y check-in'),
('Limpieza', 'Encargado de limpieza de habitaciones'),
('Gerente', 'Administra el hotel'),
('Cocina', 'Encargado de la cocina'),
('Seguridad', 'Vigilancia del hotel'),
('Mantenimiento', 'Mantenimiento general'),
('Botones', 'Asistente de maletas'),
('Camarera', 'Servicio a la habitación'),
('Contador', 'Gestión financiera');


INSERT INTO Empleados_Roles (Empleado, Rol) VALUES
(1, 2),
(2, 3),
(3, 4),
(4, 5),
(5, 8),
(6, 3),
(7, 2),
(8, 9),
(9, 6),
(10, 5);


INSERT INTO Habitaciones(Numero, Piso, Tipo, Capacidad, Precio_noche, Estado) VALUES
('101', 1, 'Simple', 1, 50.00, 'Disponible'),
('102', 1, 'Doble', 2, 80.00, 'Ocupada'),
('103', 1, 'Suite', 3, 150.00, 'Disponible'),
('104', 1, 'Doble', 2, 80.00, 'Limpieza'),
('201', 2, 'Simple', 1, 50.00, 'Disponible'),
('202', 2, 'Suite', 3, 150.00, 'Mantenimiento'),
('203', 2, 'Doble', 2, 80.00, 'Disponible'),
('301', 3, 'Suite', 3, 180.00, 'Ocupada'),
('302', 3, 'Simple', 1, 60.00, 'Disponible'),
('303', 3, 'Doble', 2, 90.00, 'Disponible');


INSERT INTO Tipos_Habitaciones (Nombre, Descripcion, Precio_base) VALUES
('Simple', 'Una cama individual', 50.00),
('Doble', 'Dos camas', 80.00),
('Suite', 'Habitación de lujo', 150.00),
('Familiar', 'Capacidad para 4 personas', 120.00),
('VIP', 'Suite presidencial', 250.00),
('Estándar', 'Habitación básica', 60.00),
('Premium', 'Con vista al mar', 200.00),
('Business', 'Con escritorio y wifi', 100.00),
('Romántica', 'Decoración especial', 170.00),
('Económica', 'Más barata', 40.00);


INSERT INTO Habitaciones_Tipos (Habitacion, Tipo) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 2),
(5, 1),
(6, 3),
(7, 2),
(8, 3),
(9, 1),
(10, 2);


INSERT INTO Reservas (Huesped, Fecha_entrada, Fecha_salida, Estado, Fecha_reserva) VALUES
(1, '2025-09-01', '2025-09-05', 'Activa', '2025-08-25'),
(2, '2025-09-10', '2025-09-12', 'Confirmada', '2025-08-30'),
(3, '2025-09-15', '2025-09-20', 'Activa', '2025-09-01'),
(4, '2025-10-01', '2025-10-05', 'Cancelada', '2025-09-10'),
(5, '2025-09-20', '2025-09-23', 'Activa', '2025-09-05'),
(6, '2025-09-25', '2025-09-30', 'Activa', '2025-09-10'),
(7, '2025-10-02', '2025-10-04', 'Confirmada', '2025-09-15'),
(8, '2025-09-18', '2025-09-22', 'Activa', '2025-09-01'),
(9, '2025-09-28', '2025-10-01', 'Activa', '2025-09-14'),
(10, '2025-09-19', '2025-09-20', 'Cancelada', '2025-09-10');


INSERT INTO Detalles_Reservas (Reserva, Habitacion, Precio_noche, Noches) VALUES
(1, 1, 50.00, 4),
(2, 2, 80.00, 2),
(3, 3, 150.00, 5),
(4, 4, 80.00, 4),
(5, 5, 50.00, 3),
(6, 6, 150.00, 5),
(7, 7, 80.00, 2),
(8, 8, 180.00, 4),
(9, 9, 60.00, 3),
(10, 10, 90.00, 1);


INSERT INTO Servicios (Nombre, Descripcion, Precio) VALUES
('Desayuno', 'Desayuno continental', 10.00),
('Lavandería', 'Servicio de lavado de ropa', 15.00),
('Spa', 'Acceso al spa del hotel', 30.00),
('Gimnasio', 'Acceso al gimnasio', 5.00),
('WiFi Premium', 'Internet de alta velocidad', 7.00),
('Estacionamiento', 'Parqueo privado', 10.00),
('Room Service', 'Servicio a la habitación', 12.00),
('Almuerzo', 'Menú del día', 20.00),
('Cena', 'Cena a la carta', 25.00),
('Minibar', 'Productos del minibar', 18.00);


INSERT INTO Reservas_Servicios (Reserva, Servicio, Cantidad) VALUES
(1, 1, 2),
(1, 2, 1),
(2, 3, 1),
(3, 4, 2),
(4, 5, 1),
(5, 6, 1),
(6, 7, 1),
(7, 8, 2),
(8, 9, 1),
(9, 10, 1);


INSERT INTO Facturas(Reserva, Fecha_emision, Total, Metodo_pago) VALUES
(1, '2025-09-05', 240.00, 'Tarjeta'),
(2, '2025-09-12', 170.00, 'Efectivo'),
(3, '2025-09-20', 750.00, 'Transferencia'),
(4, '2025-10-05', 320.00, 'Tarjeta'),
(5, '2025-09-23', 150.00, 'Efectivo'),
(6, '2025-09-30', 400.00, 'Tarjeta'),
(7, '2025-10-04', 160.00, 'Transferencia'),
(8, '2025-09-22', 720.00, 'Tarjeta'),
(9, '2025-10-01', 180.00, 'Efectivo'),
(10, '2025-09-20', 90.00, 'Efectivo');


INSERT INTO Mantenimientos (Habitacion, Descripcion, Fecha, Costo) VALUES
(6, 'Revisión de aire acondicionado', '2025-08-01', 50.00),
(4, 'Cambio de cerradura', '2025-07-15', 30.00),
(3, 'Reparación de baño', '2025-08-05', 100.00),
(5, 'Pintura de paredes', '2025-07-22', 80.00),
(9, 'Cambio de alfombra', '2025-08-12', 70.00),
(10, 'Limpieza profunda', '2025-09-01', 40.00),
(8, 'Instalación de TV', '2025-09-10', 150.00),
(2, 'Revisión eléctrica', '2025-08-18', 60.00),
(1, 'Plomería', '2025-07-25', 90.00),
(7, 'Reparación de ventana', '2025-09-05', 55.00);


INSERT INTO Proveedores (Nombre, Contacto, Telefono, Email) VALUES
('Limpio S.A.', 'Ana Pérez', '11112222', 'ana@limpio.com'),
('TecnoHotel', 'Carlos Ruiz', '22223333', 'ventas@tecnohotel.com'),
('FoodService', 'María Gómez', '33334444', 'contacto@foodservice.com'),
('DecorAR', 'Juan Torres', '44445555', 'info@decorar.com'),
('SpaZen', 'Paula Díaz', '55556666', 'atencion@spazen.com'),
('ServiClean', 'Luis Martínez', '66667777', 'lm@serviclean.com'),
('Conectados', 'Jorge Herrera', '77778888', 'jh@conectados.com'),
('MueblesPro', 'Sandra López', '88889999', 'slopez@mueblespro.com'),
('MinibarPlus', 'Carlos Sánchez', '99990000', 'carlos@minibarplus.com'),
('Uniformes SA', 'Verónica Castro', '10101010', 'ventas@uniformessa.com');


INSERT INTO Productos (Nombre, Descripcion, Stock, Precio, Proveedor) VALUES
('Jabón', 'Jabón líquido de baño', 100, 2.00, 1),
('Shampoo', 'Botella de shampoo', 100, 3.50, 1),
('Toalla', 'Toalla blanca grande', 50, 5.00, 1),
('Coca Cola', 'Bebida 350ml', 200, 1.50, 9),
('Cerveza', 'Lata de cerveza', 100, 2.00, 9),
('Agua Mineral', 'Botella 500ml', 300, 1.00, 9),
('Cepillo Dental', 'Kit dental', 80, 1.20, 1),
('Pan', 'Pan en porciones', 100, 0.80, 3),
('Queso', 'Queso en lonchas', 60, 2.50, 3),
('Fruta', 'Mix de frutas', 40, 3.00, 3);


INSERT INTO Consumos (Producto, Reserva, Cantidad, Fecha) VALUES
(4, 1, 2, '2025-09-02'),
(5, 1, 1, '2025-09-03'),
(6, 2, 3, '2025-09-11'),
(8, 3, 2, '2025-09-16'),
(9, 3, 1, '2025-09-17'),
(1, 4, 1, '2025-10-01'),
(2, 5, 2, '2025-09-21'),
(3, 6, 1, '2025-09-26'),
(7, 7, 2, '2025-10-03'),
(10, 8, 1, '2025-09-19');