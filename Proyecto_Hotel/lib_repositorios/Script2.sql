USE HOTEL_BROWN;
GO

CREATE TABLE Auditorías (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Empleado INT REFERENCES Empleados(Id) NOT NULL,
	Accion VARCHAR(20) NOT NULL,
	Descripcion VARCHAR(100) NOT NULL,
	Previo VARCHAR(MAX) NOT NULL,
	Nuevo VARCHAR(MAX) NOT NULL,
	Fecha DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	Tabla VARCHAR(20)
);

CREATE TABLE Permisos (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Empleados_Permisos (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Empleado INT REFERENCES Empleados(Id),
	Permiso INT REFERENCES Permisos(Id)
);
GO

INSERT INTO Permisos(Nombre) VALUES
('Crear Empleado'),
('Editar Empleado'),
('Elimnar Empleado'),
('Gestionar Servicios'),
('Modificar Reservas'),
('Cambiar Roles'),
('Bloquear Habitaciones'),
('Registrar Mantenimientos'),
('Gestionar Facturas'),
('Ver Inventario');

INSERT INTO Empleados_Permisos (Empleado, Permiso) VALUES
(1, 1),
(3, 2),
(1, 3),
(4, 5),
(5, 6),
(8, 7),
(2, 8), 
(4, 9),
(10, 10), 
(9, 4);