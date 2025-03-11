CREATE DATABASE [Db_Agencia_Carros];
GO

USE [Db_Agencia_Carros];
GO

CREATE TABLE [Agencia]
(
	[Id_Agencia] INT PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Ubicacion] NVARCHAR(100) NOT NULL,
);
GO 

CREATE TABLE [Marcas]
(
	[Id_Marca] INT PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE [Clientes]
(
	[Id_Cliente] INT PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Direccion] NVARCHAR(100) NOT NULL,
	[Telefono] NVARCHAR(20) NOT NULL,
	[Correo] NVARCHAR(150) UNIQUE NOT NULL
);
GO

CREATE TABLE [Vehiculos]
(
	[Id_Vehiculo] INT PRIMARY KEY IDENTITY(1,1),
	[Marca] INT FOREIGN KEY REFERENCES Marcas(Id_Marca),
	[Motor] NVARCHAR(200) NOT NULL,
	[Num_Puertas] INT NOT NULL,
	[Tipo_Combustible] NVARCHAR(50) NOT NULL,
	[Accesorios] NVARCHAR(150),
	[Activo] BIT NOT NULL DEFAULT 1,
);
GO

CREATE TABLE [Ventas]
(
	[Id_Venta] INT PRIMARY KEY IDENTITY(1,1),
	[id_Vehiculo] INT FOREIGN KEY REFERENCES Vehiculos(Id_Vehiculo) NOT NULL,
	[id_Cliente] INT FOREIGN KEY REFERENCES Clientes(Id_Cliente)NOT NULL,
	[Fecha] DATETIME DEFAULT GETDATE(),
	[Precio] DECIMAL(10,2)
);
GO

INSERT INTO [Agencia]([Nombre], [Ubicacion]) VALUES
('ITM', 'Medellín');
GO

INSERT INTO [Marcas] ([Nombre]) VALUES 
('Toyota'),
('Ford'),
('Chevrolet');
GO

INSERT INTO [Clientes] ([Nombre], [Direccion], [Telefono], [Correo]) VALUES 
('Juan Pérez', 'Calle 123, Medellín', '3012345678', 'juan.perez@email.com'),
('María López', 'Carrera 45, Medellín', '3023456789', 'maria.lopez@email.com'),
('Carlos Ramírez', 'Avenida 80, Medellín', '3034567890', 'carlos.ramirez@email.com');
GO

INSERT INTO [Vehiculos] ([Marca], [Motor], [Num_Puertas], [Tipo_Combustible], [Accesorios], [Activo]) VALUES 
(1, '2.0L Turbo', 4, 'Gasolina', 'Aire acondicionado, GPS, Bluetooth', 1),
(2, '3.5L V6', 2, 'Gasolina', 'Cámara de reversa, Asientos de cuero', 1),
(3, '1.8L', 4, 'Híbrido', 'Sensores de parqueo, Control de velocidad', 1);
GO

INSERT INTO [Ventas] ([id_Vehiculo], [id_Cliente], [Fecha], [Precio]) VALUES 
(1, 1, GETDATE(), 85000.00),
(2, 2, GETDATE(), 120000.00),
(3, 3, GETDATE(), 95000.00);
GO
