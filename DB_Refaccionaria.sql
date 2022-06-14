USE master;
GO
IF DB_ID (N'Refaccionaria') IS NOT NULL
DROP DATABASE Refaccionaria;
GO
CREATE DATABASE Refaccionaria
ON 
(NAME = Refaccionaria_dat,
FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Refaccionaria.mdf',
SIZE = 10,
MAXSIZE = 50,
FILEGROWTH = 5)
LOG ON 
(NAME = Refaccionaria_log,
FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Refaccionaria.ldf',
SIZE = 15MB,
MAXSIZE = 30MB,
FILEGROWTH = 10MB);
GO
USE Refaccionaria;
GO
--------------------------------------TABLAS----------------------------------------------
CREATE TABLE Usuario
(
idUsuario int IDENTITY(1,1),
nombre varchar (50) not null,
apellidoPaterno varchar (50) not null,
apellidoMaterno varchar (50) not null,
correo varchar (50) UNIQUE not null,
clave char (20) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Usuario PRIMARY KEY(idUsuario)
);
CREATE TABLE Accesorio
(
idAccesorio int IDENTITY(1,1),
precio numeric (10,2) not null,
descripcion varchar (100) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Accesorio PRIMARY KEY(idAccesorio)
);
CREATE TABLE Asentamiento
(
idAsentamiento int IDENTITY(1,1),
nombre varchar (50) not null,
codigoPostal char (5) not null,
idMunicipio int null,
idTipoAsentamiento int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Asentamiento PRIMARY KEY(idAsentamiento)
);
CREATE TABLE AutoParte
(
idAutoParte int IDENTITY(1,1),
descripcion varchar (100) not null,
precio numeric (10,2) not null,
idMarca int null,
idTipoAutoparte int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_AutoParte PRIMARY KEY(idAutoParte)
);
CREATE TABLE Cliente
(
idCliente int IDENTITY (1,1),
nombre varchar (50) not null,
apellidoPaterno varchar (50) not null,
apellidoMaterno varchar (50) not null,
CURP char (20) not null,
RFC char (20) not null,
idTipoCliente int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Cliente PRIMARY KEY (idCliente)
);
CREATE TABLE Compra
(
idCompra int IDENTITY (1,1),
fecha datetime null,
monto numeric (10,2) not null,
detalles varchar (100) not null,
--ARTICULO varchar (50) not null,--------------------------------------
idFormaPago int null,
idFactura int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Compra PRIMARY KEY (idCompra)
);
CREATE TABLE Descuento
(
idDescuento int IDENTITY (1,1),
fechalimite datetime  null, ------Revisar----
monto varchar (10) not null,
detalles varchar (100) not null,
idVenta int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Descuento PRIMARY KEY (idDescuento)
);
CREATE TABLE Empleado
(
idEmpleado int IDENTITY (1,1),
nombre varchar (50) not null,
apellidoPaterno varchar (50) not null,
apellidoMaterno varchar (50) not null,
fechaNacimiento datetime null, /*Revisa datetime*/
CURP char (20) not null,
RFC char (20) not null,
NSS char (20) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Empleado PRIMARY KEY (idEmpleado)
);
CREATE TABLE EquipoComputo
(
idEquipoComputo int IDENTITY(1,1),
nombre varchar (50) not null,
precio numeric (10,2) not null,
marca varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_EquipoComputo PRIMARY KEY(idEquipoComputo)
);
CREATE TABLE Estado
(
idEstado int IDENTITY(1,1),
nombre varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Estado PRIMARY KEY(idEstado)
);
CREATE TABLE Factura
(
idFactura int IDENTITY(1,1),
fecha datetime not null,
monto numeric (10,2) not null,
detalles varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Factura PRIMARY KEY(idFactura)
);
CREATE TABLE FormaPago
(
idFormaPago int IDENTITY(1,1),
nombre varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_FormaPago PRIMARY KEY(idFormaPago)
);
CREATE TABLE Marca
(
idMarca int IDENTITY(1,1),
nombre varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Marca PRIMARY KEY(idMarca)
);
CREATE TABLE Moviliario
(
idMoviliario int IDENTITY(1,1),
nombre varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Moviliario PRIMARY KEY(idMoviliario)
);
CREATE TABLE Municipio
(
idMunicipio int IDENTITY(1,1),
nombre varchar (50) not null,
idEstado int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Municipio PRIMARY KEY(idMunicipio)
);
--------------------------------------------------------------------------------------------
CREATE TABLE Producto
(
idProducto int IDENTITY(1,1),
---nombre varchar (50) not null
descripcion varchar (100) not null,
precio numeric (10,2) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Producto PRIMARY KEY(idProducto)
);
CREATE TABLE Proveedor
(
idProveedor int IDENTITY (1,1),
nombre varchar (50) not null,
apellidoPaterno varchar (50) not null,
apellidoMaterno varchar (50) not null,
CURP char (15) not null,
RFC char (15) not null,
NSS char (10) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Proveedor PRIMARY KEY (idProveedor)
);
CREATE TABLE Publicidad
(
idPublicidad int IDENTITY(1,1),
Tipo varchar (50) not null,
descripcion varchar (100) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Publicidad PRIMARY KEY(idPublicidad)
);
CREATE TABLE Quimicos
(
idQuimicos int IDENTITY(1,1),
precio numeric (10,2) not null,
descripcion varchar (100) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Quimicos PRIMARY KEY(idQuimicos)
);
CREATE TABLE Sucursal
(
idSucursal int IDENTITY(1,1),
nombre varchar (50) not null,
direccion varchar (150) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Sucursal PRIMARY KEY(idSucursal)
);
CREATE TABLE TipoAsentamiento
(
idTipoAsentamiento int IDENTITY(1,1),
nombre varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_TipoAsentamiento PRIMARY KEY(idTipoAsentamiento)
);
CREATE TABLE TipoAutoparte
(
idTipoAutoparte int IDENTITY(1,1),
nombre varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_TipoAutoparte PRIMARY KEY(idTipoAutoparte)
);
CREATE TABLE TipoEmpleado
(
idTipoEmpleado int IDENTITY(1,1),
nombre varchar (50) not null,
idEmpleado int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_TipoEmpleado PRIMARY KEY(idTipoEmpleado)
);
CREATE TABLE TipoProveedor
(
idTipoProveedor int IDENTITY(1,1),
nombre varchar (50) not null,
idProveedor int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_TipoProveedor PRIMARY KEY(idTipoProveedor)
);
CREATE TABLE Venta
(
idVenta int IDENTITY(1,1),
fecha datetime null,
monto numeric (10,2) not null,
descripcion varchar (50) not null,
idFormaPago int null,
idFactura int null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Venta PRIMARY KEY(idVenta)
);
CREATE TABLE Zona
(
idZona int IDENTITY(1,1),
nombre varchar (50) not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_Zona PRIMARY KEY(idZona)
);
----------------------------------------------------------------------------
CREATE TABLE AutoparteSucursal
(
idAutoparteSucursal int IDENTITY(1,1),
idAutoparte int not null,
idSucursal int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_AutoparteSucursal PRIMARY KEY (idAutoparteSucursal)
);
CREATE TABLE ClienteCompra
(
idClienteCompra int IDENTITY(1,1),
idCliente int not null,
idCompra int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_ClienteCompra PRIMARY KEY (idClienteCompra)
);
CREATE TABLE ClienteProducto
(
idClienteProducto int IDENTITY(1,1),
idCliente int not null,
idProducto int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_ClienteProducto PRIMARY KEY (idClienteProducto)
);
CREATE TABLE ClienteSucursal
(
idClienteSucursal int IDENTITY(1,1),
idCliente int not null,
idSucursal int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_ClienteSucursal PRIMARY KEY (idClienteSucursal)
);
CREATE TABLE EmpleadoProducto
(
idEmpleadoProducto int IDENTITY(1,1),
idEmpleado int not null,
idProducto int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_EmpleadoProducto PRIMARY KEY (idEmpleadoProducto)
);
CREATE TABLE ProductoCompra
(
idProductoCompra int IDENTITY(1,1),
idProducto int not null,
idCompra int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_ProductoCompra PRIMARY KEY (idProductoCompra)
);
CREATE TABLE QuimicosSucursal
(
idQuimicosSucursal int IDENTITY(1,1),
idQuimicos int not null,
idSucursal int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_QuimicosSucursal PRIMARY KEY (idQuimicosSucursal)
);
CREATE TABLE SucursalAccesorio
(
idSucursalAccesorio int IDENTITY(1,1),
idSucursal int not null,
idAccesorio int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_SucursalAccesorio PRIMARY KEY (idSucursalAccesorio)
);
CREATE TABLE SucursalEmpleado
(
idSucursalEmpleado int IDENTITY(1,1),
idSucursal int not null,
idEmpleado int not null,
fechaIngreso datetime null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_SucursalEmpleado PRIMARY KEY (idSucursalEmpleado)
);
CREATE TABLE SucursalEquipoComputo
(
idSucursalEquipoComputo int IDENTITY(1,1),
idSucursal int not null,
idEquipoComputo int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_SucursalEquipoComputo PRIMARY KEY (idSucursalEquipoComputo)
);
CREATE TABLE SucursalEstado
(
idSucursalEstado int IDENTITY(1,1),
idSucursal int not null,
idEstado int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_SucursalEstado PRIMARY KEY (idSucursalEstado)
);
CREATE TABLE SucursalMoviliario
(
idSucursalMoviliario int IDENTITY(1,1),
idSucursal int not null,
idMoviliario int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_SucursalMoviliario PRIMARY KEY (idSucursalMoviliario)
);
CREATE TABLE SucursalProveedor
(
idSucursalProveedor int IDENTITY(1,1),
idSucursal int not null,
idProveedor int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_SucursalProveedor PRIMARY KEY (idSucursalProveedor)
);
CREATE TABLE SucursalPublicidad
(
idSucursalPublicidad int IDENTITY(1,1),
idSucursal int not null,
idPublicidad int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_SucursalPublicidad PRIMARY KEY (idSucursalPublicidad)
);
CREATE TABLE TipoAsentamientoZona
(
idTipoAsentamientoZona int IDENTITY(1,1),
idTipoAsentamiento int not null,
idZona int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_TipoAsentamientoZona PRIMARY KEY (idTipoAsentamientoZona)
);
CREATE TABLE VentaEmpleado
(
idVentaEmpleado int IDENTITY(1,1),
idVenta int not null,
idEmpleado int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_VentaEmpleado PRIMARY KEY (idVentaEmpleado)
);
CREATE TABLE ProductoVenta
(
idProductoVenta int IDENTITY(1,1),
idProducto int not null,
idVenta int not null,
estatus bit default 1 not null,
idUsuarioCrea int null,
fechaCrea datetime null,
idUsuarioModifica int default null,
fechaModifica datetime default null
CONSTRAINT PK_ProductoVenta PRIMARY KEY (idProductoVenta)
);
------------------------------------------------------------------------------------------------
CREATE INDEX IX_Accesorio ON Accesorio(idAccesorio);
GO
CREATE INDEX IX_Asentamiento ON Asentamiento(idAsentamiento);
GO
CREATE INDEX IX_Autoparte ON Autoparte(idAutoparte);
GO
CREATE INDEX IX_Cliente ON Cliente(idCliente);
GO
CREATE INDEX IX_Compra ON Compra(idCompra);
GO
CREATE INDEX IX_Descuento ON Descuento(idDescuento);
GO
CREATE INDEX IX_Empleado ON Empleado(idEmpleado);
GO
CREATE INDEX IX_EquipoComputo ON EquipoComputo(idEquipoComputo);
GO
CREATE INDEX IX_Estado ON Estado(idEstado);
GO
CREATE INDEX IX_Factura ON Factura(idFactura);
GO
CREATE INDEX IX_FormaPago ON FormaPago(idFormaPago);
GO
CREATE INDEX IX_Marca ON Marca(idMarca);
GO
CREATE INDEX IX_Moviliario ON Moviliario(idMoviliario);
GO
CREATE INDEX IX_Municipio ON Municipio(idMunicipio);
GO
CREATE INDEX IX_Producto ON Producto(idProducto);
GO
CREATE INDEX IX_Proveedor ON Proveedor(idProveedor);
GO
CREATE INDEX IX_Publicidad ON Publicidad(idPublicidad);
GO
CREATE INDEX IX_Quimicos ON Quimicos(idQuimicos);
GO
CREATE INDEX IX_Sucursal ON Sucursal(idSucursal);
GO
CREATE INDEX IX_TipoAsentamiento ON TipoAsentamiento(idTipoAsentamiento);
GO
CREATE INDEX IX_TipoAutoparte ON TipoAutoparte(idTipoAutoparte);
GO
CREATE INDEX IX_TipoEmpleado ON TipoEmpleado(idTipoEmpleado);
GO
CREATE INDEX IX_TipoProveedor ON TipoProveedor(idTipoProveedor);
GO
CREATE INDEX IX_Venta ON Venta(idVenta);
GO
CREATE INDEX IX_Zona ON Zona(idZona);
GO
CREATE INDEX IX_AutoparteSucursal ON AutoparteSucursal(idAutoparteSucursal);
GO
CREATE INDEX IX_ClienteCompra ON ClienteCompra(idClienteCompra);
GO
CREATE INDEX IX_ClienteProducto ON ClienteProducto(idClienteProducto);
GO
CREATE INDEX IX_ClienteSucursal ON ClienteSucursal(idClienteSucursal);
GO
CREATE INDEX IX_EmpleadoProducto ON EmpleadoProducto(idEmpleadoProducto);
GO
CREATE INDEX IX_ProductoCompra ON ProductoCompra(idProductoCompra);
GO
CREATE INDEX IX_QuimicosSucursal ON QuimicosSucursal(idQuimicosSucursal);
GO
CREATE INDEX IX_SucursalAccesorio ON SucursalAccesorio(idSucursalAccesorio);
GO
CREATE INDEX IX_SucursalEmpleado ON SucursalEmpleado(idSucursalEmpleado);
GO
CREATE INDEX IX_SucursalEquipoComputo ON SucursalEquipoComputo(idSucursalEquipoComputo);
GO
CREATE INDEX IX_SucursalEstado ON SucursalEstado(idSucursalEstado);
GO
CREATE INDEX IX_SucursalMoviliario ON SucursalMoviliario(idSucursalMoviliario);
GO
CREATE INDEX IX_SucursalProveedor ON SucursalProveedor(idSucursalProveedor);
GO
CREATE INDEX IX_SucursalPublicidad ON SucursalPublicidad(idSucursalPublicidad);
GO
CREATE INDEX IX_TipoAsentamientoZona ON TipoAsentamientoZona(idTipoAsentamientoZona);
GO
CREATE INDEX IX_VentaEmpleado ON VentaEmpleado(idVentaEmpleado);
GO
CREATE INDEX IX_ProductoVenta ON ProductoVenta(idProductoVenta);
GO
------------------------------------------------------------------------------------------
ALTER TABLE Usuario
ADD CONSTRAINT FKUsuarioUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Usuario
ADD CONSTRAINT FKUsuarioUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Accesorio
ADD CONSTRAINT FK_AccesorioUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Accesorio
ADD CONSTRAINT FK_AccesorioUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Asentamiento
ADD CONSTRAINT FK_AsentamientoMunicipio
FOREIGN KEY (idMunicipio) REFERENCES Municipio(idMunicipio);
GO
ALTER TABLE Asentamiento
ADD CONSTRAINT FK_AsentamientoTipoAsentamiento
FOREIGN KEY (idTipoAsentamiento) REFERENCES TipoAsentamiento(idTipoAsentamiento);
GO
ALTER TABLE Asentamiento
ADD CONSTRAINT FK_AsentamientoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Asentamiento
ADD CONSTRAINT FK_AsentamientoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Autoparte
ADD CONSTRAINT FK_AutoparteMarca
FOREIGN KEY (idMarca) REFERENCES Marca(idMarca);
GO
ALTER TABLE Autoparte
ADD CONSTRAINT FK_AutoparteTipoAutoparte
FOREIGN KEY (idTipoAutoparte) REFERENCES TipoAutoparte(idTipoAutoparte);
GO
ALTER TABLE Autoparte
ADD CONSTRAINT FK_AutoparteUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Autoparte
ADD CONSTRAINT FK_AutoparteUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Cliente
ADD CONSTRAINT FK_ClienteUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Cliente
ADD CONSTRAINT FK_ClienteUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Compra
ADD CONSTRAINT FK_CompraFormaPago
FOREIGN KEY (idFormaPago) REFERENCES FormaPago(idFormaPago);
GO
ALTER TABLE Compra
ADD CONSTRAINT FK_CompraFactura
FOREIGN KEY (idFactura) REFERENCES Factura(idFactura);
GO
ALTER TABLE Compra
ADD CONSTRAINT FK_CompraUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Compra
ADD CONSTRAINT FK_CompraUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Descuento
ADD CONSTRAINT FK_DescuentoVenta
FOREIGN KEY (idVenta) REFERENCES Venta(idVenta);
GO
ALTER TABLE Descuento
ADD CONSTRAINT FK_DescuentoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Descuento
ADD CONSTRAINT FK_DescuentoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Empleado
ADD CONSTRAINT FK_EmpleadoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Empleado
ADD CONSTRAINT FK_EmpleadoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE EquipoComputo
ADD CONSTRAINT FK_EquipoComputoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE EquipoComputo
ADD CONSTRAINT FK_EquipoComputoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Estado
ADD CONSTRAINT FK_EstadoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Estado
ADD CONSTRAINT FK_EstadoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Factura
ADD CONSTRAINT FK_FacturaUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Factura
ADD CONSTRAINT FK_FacturaUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE FormaPago
ADD CONSTRAINT FK_FormaPagoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE FormaPago
ADD CONSTRAINT FK_FormaPagoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Marca
ADD CONSTRAINT FK_MarcaUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Marca
ADD CONSTRAINT FK_MarcaUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Moviliario
ADD CONSTRAINT FK_MoviliarioUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Moviliario
ADD CONSTRAINT FK_MoviliarioUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Municipio
ADD CONSTRAINT FK_MunicipioEstado
FOREIGN KEY (idEstado) REFERENCES Estado(idEstado);
GO
ALTER TABLE Municipio
ADD CONSTRAINT FK_MunicipioUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Municipio
ADD CONSTRAINT FK_MunicipioUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Producto
ADD CONSTRAINT FK_ProductoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Producto
ADD CONSTRAINT FK_ProductoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Proveedor 
ADD CONSTRAINT FK_ProveedorUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Proveedor 
ADD CONSTRAINT FK_ProveedorUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Publicidad 
ADD CONSTRAINT FK_PublicidadUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Publicidad 
ADD CONSTRAINT FK_PublicidadUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Quimicos 
ADD CONSTRAINT FK_QuimicosUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Quimicos 
ADD CONSTRAINT FK_QuimicosUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Sucursal 
ADD CONSTRAINT FK_SucursalUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Sucursal 
ADD CONSTRAINT FK_SucursalUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoAsentamiento
ADD CONSTRAINT FK_TipoAsentamientoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoAsentamiento
ADD CONSTRAINT FK_TipoAsentamientoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoAutoparte
ADD CONSTRAINT FK_TipoAutoparteUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoAutoparte
ADD CONSTRAINT FK_TipoAutoparteUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoEmpleado
ADD CONSTRAINT FK_TipoEmpleadoEmpleado
FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado);
GO
ALTER TABLE TipoEmpleado
ADD CONSTRAINT FK_TipoEmpleadoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoEmpleado
ADD CONSTRAINT FK_TipoEmpleadoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoProveedor
ADD CONSTRAINT FK_TipoProveedorProveedor
FOREIGN KEY (idProveedor) REFERENCES Proveedor(idProveedor);
GO
ALTER TABLE TipoProveedor
ADD CONSTRAINT FK_TipoProveedorUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoProveedor
ADD CONSTRAINT FK_TipoProveedorUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Venta
ADD CONSTRAINT FK_VentaFormaPago
FOREIGN KEY (idFormaPago) REFERENCES FormaPago(idFormaPago);
GO
ALTER TABLE Venta
ADD CONSTRAINT FK_VentaFactura
FOREIGN KEY (idFactura) REFERENCES Factura(idFactura);
GO
ALTER TABLE Venta
ADD CONSTRAINT FK_VentaUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Venta
ADD CONSTRAINT FK_VentaUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Zona
ADD CONSTRAINT FK_ZonaUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE Zona
ADD CONSTRAINT FK_ZonaUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
---------------------------n---m----------------------------------------
ALTER TABLE AutoparteSucursal
ADD CONSTRAINT FK_AutoparteSucursalAutoparte
FOREIGN KEY (idAutoparte) REFERENCES Autoparte(idAutoparte);
GO
ALTER TABLE AutoparteSucursal
ADD CONSTRAINT FK_AutoparteSucursalSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE AutoparteSucursal
ADD CONSTRAINT FK_AutoparteSucursalUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE AutoparteSucursal
ADD CONSTRAINT FK_AutoparteSucursalUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ClienteCompra
ADD CONSTRAINT FK_ClienteCompraCliente
FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente);
GO
ALTER TABLE ClienteCompra
ADD CONSTRAINT FK_ClienteCompraCompra
FOREIGN KEY (idCompra) REFERENCES Compra(idCompra);
GO
ALTER TABLE ClienteCompra
ADD CONSTRAINT FK_ClienteCompraUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ClienteCompra
ADD CONSTRAINT FK_ClienteCompraUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ClienteProducto
ADD CONSTRAINT FK_ClienteProductoCliente
FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente);
GO
ALTER TABLE ClienteProducto
ADD CONSTRAINT FK_ClienteProductoProducto
FOREIGN KEY (idProducto) REFERENCES Producto(idProducto);
GO
ALTER TABLE ClienteProducto
ADD CONSTRAINT FK_ClienteProductoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ClienteProducto
ADD CONSTRAINT FK_ClienteProductoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ClienteSucursal
ADD CONSTRAINT FK_ClienteSucursalCliente
FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente);
GO
ALTER TABLE ClienteSucursal
ADD CONSTRAINT FK_ClienteSucursalSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE ClienteSucursal
ADD CONSTRAINT FK_ClienteSucursalUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ClienteSucursal
ADD CONSTRAINT FK_ClienteSucursalUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE EmpleadoProducto
ADD CONSTRAINT FK_EmpleadoProductoEmpleado
FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado);
GO
ALTER TABLE EmpleadoProducto
ADD CONSTRAINT FK_EmpleadoProductoProducto
FOREIGN KEY (idProducto) REFERENCES Producto(idProducto);
GO
ALTER TABLE EmpleadoProducto
ADD CONSTRAINT FK_EmpleadoProductoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE EmpleadoProducto
ADD CONSTRAINT FK_EmpleadoProductoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ProductoCompra
ADD CONSTRAINT FK_ProductoCompraProducto
FOREIGN KEY (idProducto) REFERENCES Producto(idProducto);
GO
ALTER TABLE ProductoCompra
ADD CONSTRAINT FK_ProductoCompraCompra
FOREIGN KEY (idCompra) REFERENCES Compra(idCompra);
GO
ALTER TABLE ProductoCompra
ADD CONSTRAINT FK_ProductoCompraUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ProductoCompra
ADD CONSTRAINT FK_ProductoCompraUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE QuimicosSucursal
ADD CONSTRAINT FK_QuimicosSucursalQuimicos
FOREIGN KEY (idQuimicos) REFERENCES Quimicos(idQuimicos);
GO
ALTER TABLE QuimicosSucursal
ADD CONSTRAINT FK_QuimicosSucursalSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE QuimicosSucursal
ADD CONSTRAINT FK_QuimicosSucursalUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE QuimicosSucursal
ADD CONSTRAINT FK_QuimicosSucursalUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalAccesorio
ADD CONSTRAINT FK_SucursalAccesorioSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE SucursalAccesorio
ADD CONSTRAINT FK_SucursalAccesorioAccesorio
FOREIGN KEY (idAccesorio) REFERENCES Accesorio(idAccesorio);
GO
ALTER TABLE SucursalAccesorio
ADD CONSTRAINT FK_SucursalAccesorioUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalAccesorio
ADD CONSTRAINT FK_SucursalAccesorioUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalEmpleado
ADD CONSTRAINT FK_SucursalEmpleadoSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE SucursalEmpleado
ADD CONSTRAINT FK_SucursalEmpleadoEmpleado
FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado);
GO
ALTER TABLE SucursalEmpleado
ADD CONSTRAINT FK_SucursalEmpleadoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalEmpleado
ADD CONSTRAINT FK_SucursalEmpleadoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalEquipoComputo
ADD CONSTRAINT FK_SucursalEquipoComputoSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE SucursalEquipoComputo
ADD CONSTRAINT FK_SucursalEquipoComputoEquipoComputo
FOREIGN KEY (idEquipoComputo) REFERENCES EquipoComputo(idEquipoComputo);
GO
ALTER TABLE SucursalEquipoComputo
ADD CONSTRAINT FK_SucursalEquipoComputoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalEquipoComputo
ADD CONSTRAINT FK_SucursalEquipoComputoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalEstado
ADD CONSTRAINT FK_SucursalEstadoSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE SucursalEstado
ADD CONSTRAINT FK_SucursalEstadoEstado
FOREIGN KEY (idEstado) REFERENCES Estado(idEstado);
GO
ALTER TABLE SucursalEstado
ADD CONSTRAINT FK_SucursalEstadoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalEstado
ADD CONSTRAINT FK_SucursalEstadoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalMoviliario
ADD CONSTRAINT FK_SucursalMoviliarioSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE SucursalMoviliario
ADD CONSTRAINT FK_SucursalMoviliarioMoviliario
FOREIGN KEY (idMoviliario) REFERENCES Moviliario(idMoviliario);
GO
ALTER TABLE SucursalMoviliario
ADD CONSTRAINT FK_SucursalMoviliarioUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalMoviliario
ADD CONSTRAINT FK_SucursalMoviliarioUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalProveedor
ADD CONSTRAINT FK_SucursalProveedorSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE SucursalProveedor
ADD CONSTRAINT FK_SucursalProveedorProveedor
FOREIGN KEY (idProveedor) REFERENCES Proveedor(idProveedor);
GO
ALTER TABLE SucursalProveedor
ADD CONSTRAINT FK_SucursalProveedorUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalProveedor
ADD CONSTRAINT FK_SucursalProveedorUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalPublicidad
ADD CONSTRAINT FK_SucursalPublicidadSucursal
FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal);
GO
ALTER TABLE SucursalPublicidad
ADD CONSTRAINT FK_SucursalPublicidadPublicidad
FOREIGN KEY (idPublicidad) REFERENCES Publicidad(idPublicidad);
GO
ALTER TABLE SucursalPublicidad
ADD CONSTRAINT FK_SucursalPublicidadUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE SucursalPublicidad
ADD CONSTRAINT FK_SucursalPublicidadUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoAsentamientoZona
ADD CONSTRAINT FK_TipoAsentamientoZonaTipoAsentamiento
FOREIGN KEY (idTipoAsentamiento) REFERENCES TipoAsentamiento(idTipoAsentamiento);
GO
ALTER TABLE TipoAsentamientoZona
ADD CONSTRAINT FK_TipoAsentamientoZonaZona
FOREIGN KEY (idZona) REFERENCES Zona(idZona);
GO
ALTER TABLE TipoAsentamientoZona
ADD CONSTRAINT FK_TipoAsentamientoZonaUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE TipoAsentamientoZona
ADD CONSTRAINT FK_TipoAsentamientoZonaUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE VentaEmpleado
ADD CONSTRAINT FK_VentaEmpleadoVenta
FOREIGN KEY (idVenta) REFERENCES Venta(idVenta);
GO
ALTER TABLE VentaEmpleado
ADD CONSTRAINT FK_VentaEmpleadoEmpleado
FOREIGN KEY (idEmpleado) REFERENCES Empleado(idEmpleado);
GO
ALTER TABLE VentaEmpleado
ADD CONSTRAINT FK_VentaEmpleadoUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE VentaEmpleado
ADD CONSTRAINT FK_VentaEmpleadoUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ProductoVenta
ADD CONSTRAINT FK_ProductoVentaProducto
FOREIGN KEY (idProducto) REFERENCES Producto(idProducto);
GO
ALTER TABLE ProductoVenta
ADD CONSTRAINT FK_ProductoVentaVenta
FOREIGN KEY (idVenta) REFERENCES Venta(idVenta);
GO
ALTER TABLE ProductoVenta
ADD CONSTRAINT FK_ProductoVentaUsuarioCrea 
FOREIGN KEY (idUsuarioCrea) REFERENCES Usuario(idUsuario);
GO
ALTER TABLE ProductoVenta
ADD CONSTRAINT FK_ProductoVentaUsuarioModifica 
FOREIGN KEY (idUsuarioModifica) REFERENCES Usuario(idUsuario);
GO
-----------------------------------------------------------------------------------------------------------------
INSERT INTO Usuario(nombre,apellidoPaterno,apellidoMaterno,correo,clave)
VALUES ('Alan Geovannie','Morales','Salazar','I19050458@monclova.tecnm.mx','Tec12345.'),
       ('Luis Adrian','Ganzalo','Alvarez','Admin','Tec12345.')

INSERT INTO Accesorio(precio,descripcion)
VALUES (700,'Canastilla o parrilla Universal porta equipaje para autos'),
	   (100,'Soporte Base Celular Automóvil Carro Chupon Brazo Universal'),
	   (120,' Cargador para Auto PD TIPO C con un cable de 1M'),
	   (600,'Ventilador para Auto')
	   
INSERT INTO Cliente(nombre,apellidoPaterno,apellidoMaterno,CURP,RFC)
VALUES ('Jesus Alonso','Guiterrez','Vazquez','JUSGVZJDMI397','JSY76SSS0'),
	   ('Pedro Adrian','Perez','Gonzales','PODAN8EJDII3','9838I829'),
	   ('Luis Jorge','Alvarez','Cruz','LKJACOK8676Y2','LOS73US88'),
	   ('Perla Evelin','Carrillo','Avitia','PEEV8IC4623O93','OPAJE7J5G'),
	   ('Gerardo Daniel','Anibal','Nuñez','GDNV9O83IOEK3','GD9OJNOJEI9'),
	   ('Pablo Gael','Ortiz','Salaz','POO8I7E3S09OO9','PJDU73HG33'),
	   ('Raul Gil','Jordan','Orozco','RG83IOO939BE93','RRGGOEJ8I3I'),
	   ('Damian Erneste','Rodriguez','Martinez','D9IE8M92IWKWII','DI83I9EKW'),
       ('Felipe David','Sanchez','Montalvo','FS7HDKOO39IE33','MS9O3FD8II'),
	   ('Carlos Eduardo','Robles','Salazar','CE8I2IIDKRKJJD','SAO89I29EJ')

INSERT INTO Empleado (nombre,apellidoPaterno,apellidoMaterno,fechaNacimiento,CURP,RFC,NSS)
VALUES ('Luis Almendaris' ,'Tovar','Ramos','1996-09-15','LST7URHYEKE8I9O','73UE73U3777','85459666'),
       ('Angela Paola' ,'Garcia','Perez','1990-02-06','AEP90AG77JKSIIK','POI877GHUIIJ','84352321'),
       ('Jose Raul' ,'Barrientos','Oviedo','1996-09-15','LST7URHYEKE8I9O','73UE73U3777','85459666'),
       ('Alfonso Alberto' ,'Badolero','Casillas','1998-01-16','A8KVEIIA9ECSLLA','A8I8U6Y5T4','12469731'),
       ('Emily  Daiela' ,'Vazquez','Obrera','1994-09-03','EM8D9O9VOO998I','E36YD7O9O','147892400'),
       ('Raul Carlos' ,'Sandoval','Perez','1997-12-08','RO9C6Y6S6Y63JK','R858LS00256','65993200'),
       ('Sofia Prisila' ,'Ruiz','Torrez','1990-06-19','S0P84ITT8JIKEL9','S7UPR9O9R9OO','0865596262'),
       ('Luis Almendaris' ,'Tovar','Ramos','1993-09-15','LST7URHYEKE8I9O','73UE73U3777','85459666'),
       ('Luis Almendaris' ,'Tovar','Ramos','1996-02-25','LST7URHYEKE8I9O','73UE73U3777','85459666'),
       ('Luis Almendaris' ,'Tovar','Ramos','1995-11-28','LST7URHYEKE8I9O','73UE73U3777','85459666')
       

INSERT INTO EquipoComputo(nombre,marca,precio)
VALUES ('Computadora de Esvritorio','HP',5000),
	   ('Impresora','HP',2000),
	   ('Lector de codigo de barras','IMPORMEL',500),
	   ('Bascula Digital','Practiksa',2000),
	   ('Impresora de Ticket','SICAR',800),
	   ('Cajon de Dinero','Gutstark',1000)
			
INSERT INTO Estado(nombre)
VALUES ('Aguascalientes'),
       ('Baja California'),
       ('Baja California Sur'),
       ('Campeche'),
	   ('Chiapas'),
	   ('Chihuahua'),
	   ('Ciudad de México'),
	   ('Coahuila de Zaragoza'),
	   ('Colima'),
	   ('Durango'),
	   ('Guanajuato'),
	   ('Guerrero'),
	   ('Hidalgo'),
	   ('Jalisco'),
	   ('México'),
	   ('Michoacán de Ocampo'),
	   ('Morelos'),
	   ('Nayarit'),
	   ('Nuevo León'),
	   ('Oaxaca'),
	   ('Puebla'),
	   ('Querétaro'),
	   ('Quintana Roo'),
	   ('San Luis Potosí'),
	   ('Sinaloa'),
	   ('Sonora'),
	   ('Tabasco'),
	   ('Tamaulipas'),
	   ('Tlaxcala'),
	   ('Veracruz'),
	   ('Yucatán'),
	   ('Zacatecas')
	   
INSERT INTO Factura(fecha,monto,detalles)
VALUES (getdate(),450,'Compra'),
       (getdate(),500,'Compra'),
	   (getdate(),2155,'Compra'),
	   (getdate(),300,'Compra'),
	   (getdate(),100,'Compra'),
	   (getdate(),1892,'Compra'),
	   (getdate(),556,'Compra'),
	   (getdate(),800,'Compra'),
	   (getdate(),1204,'Compra')

INSERT INTO FormaPago(nombre)
VALUES ('Tarjeta'),
       ('Efectivo'),
	   ('Credito'),
	   ('Vale')
	  
INSERT INTO Marca(nombre)
VALUES ('Ford'),
       ('Chevrolet'),
	   ('Mazda'),
	   ('Nissan'),
	   ('Honda'),
	   ('Toyota'),
	   ('Volkswagen'),
	   ('Dodge'),
	   ('GMC'),
	   ('Suzuki')

INSERT INTO Moviliario(nombre)
VALUES ('Vitrina'),
       ('Apartador'),
	   ('Panel con gabetas'),
	   ('Organizador de repisas'),
	   ('Estanteria'),
	   ('Banco'),
	   ('Silla'),
	   ('Escritorio'),
	   ('Mesa'),
	   ('Exhibidor'),
	   ('Anaqueles'),
	   ('Mostrador')

INSERT INTO Producto(descripcion,precio)
VALUES ('Filtro De Aire Alto Flujo Universal',200),
	   ('Filtro De Aceite Gonher',100),
	   ('Filtro de gasolina',100),
	   ('Carburador ',500),
	   ('Batería ',1500),
	   ('Bujias',50),
	   ('Sensor De Carga de Aire',450),
	   ('Junta de Cárter de Aceite de Motor',150),
	   ('Junta O Empaque Cárter Transmisión Automática',100),
	   ('Filtro De Transmision Automatica',200),
	   ('Bomba De Gasolina Electrica Universal',500),
	   ('Discos de Freno',1000),
	   ('Balatas de Freno',300),
	   ('Balatas de Tambor',255),
	   ('Banda para Motor',120),
	   ('Distribuidor eléctrico de alta calidad',1600),
	   ('Amortiguadores para coche, suspensión',2000),
	   ('Mofle o Escape',3000),
	   ('Aceite para motor de 1 Litro',200),
       ('Aceite para transmisión automática de 1 Litro',150),
	   ('Aceite para transmisión manual de 1 Litro',200),
	   ('Aceite para direccion hidraulica de 1 Litro',90),
	   ('Liquido para frenos disco y tambor de 1 Litro',100),
	   ('Aceite Para Diferencial de 1 Litro',100)
	   
INSERT INTO Proveedor(nombre,apellidoPaterno,apellidoMaterno,CURP,RFC,NSS)
VALUES ('Salomon Daniel','Sendero','Luna','S9IJDSL9OI8','7U6T6T0O9K','41056161'),
       ('Alexis Hasiel','Santos','Perez','AL8IENMOPXEI','93IIEIEEEO','48484232'),
       ('Jesus Raul','Menchaca','Alvarez','J8JRRAI3KALZ','J83IIE3UHH','03256786'),
       ('Armando Mario','Garcia','Peralta','AR7U7MAR99O','9OBAYRMA45','09798881'),
       ('Osacar Alonso','Zapata','Flores','OS93OOOZZOKO','ORJIR45445','15984755'),
       ('Matias Eduardo','Valdez','Montero','MT03PED903L','OEI8339939','03684541'),
       ('Kevin Yair','Barajas','Cuevas','KE8UE9BJAS8BAV','I82U888UWW','78884547')
       
INSERT INTO Publicidad(Tipo,descripcion)
VALUES ('A','EN Internet'),
       ('B','En Televicion'),
       ('C','En la Radio'),
       ('D','En el Periodico'),
       ('E','En You Tube'),
	   ('F','En facebook'),
       ('G','En Comerciales'),
       ('H','En Revistas'),
       ('I','En Anuncios'),
       ('J','En Bolantes')

INSERT INTO Quimicos(descripcion,precio)
VALUES ('Aceite para motor de 1 Litro',200),
       ('Aceite para transmisión automática de 1 Litro',150),
	   ('Aceite para transmisión manual de 1 Litro',200),
	   ('Aceite para direccion hidraulica de 1 Litro',90),
	   ('Liquido para frenos disco y tambor de 1 Litro',100),
	   ('Aceite Para Diferencial de 1 Litro',100)

INSERT INTO Sucursal(nombre,direccion)
VALUES ('NOLO','Blvd Harold R. Pape 2020-B, Los Nogales, 25730 Monclova, Coah.'),
       ('B','San Buena 40, Pemex, 25630 Frontera, Coah.'),
	   ('X','Blvd Harold R. Pape 1243, 18 de Marzo, 25760 Monclova, Coah.')
       
INSERT INTO TipoAutoparte(nombre)
VALUES ('Partes Interiores'),
       ('Partes Exteriores'),
	   ('Partes de Motor')

INSERT INTO Zona(nombre)
VALUES ('Urbana'),
       ('Rural')
----------------------------------------------------------------------------------
INSERT INTO Municipio(nombre,idEstado)
VALUES  ('Frontera',8),
		('Juárez',8),
		('Múzquiz',8),
		('Piedras Negras',8),
		('Matamoros',8),
		('Hidalgo',8),
		('Viesca',8),
		('Nava',8),
		('General Cepeda',8),
		('Candela',8),
		('San Pedro',8),
		('San Juan de Sabinas',8),
		('San Buenaventura',8),
		('Abasolo',8),
		('Guerrero',8),
		('Zaragoza',8),
		('Cuatro Ciénegas',8),
		('Arteaga',8),
		('Francisco I. Madero',8),
		('Parras',8),
		('Ocampo',8),
		('Nadadores',8),
		('Morelos',8),
		('Saltillo',8),
		('Ramos Arizpe',8),
		('Progreso',8),
		('Allende',8),
		('Torreón',8),
		('Lamadrid',8),
		('Sabinas',8),
		('Acuña',8),
		('Sierra Mojada',8),
		('Jiménez',8),
		('Monclova',8),
		('Escobedo',8),
		('Villa Unión',8),
		('Sacramento',8),
		('Castaños',8)

INSERT INTO TipoEmpleado(nombre,idEmpleado)
VALUES ('A',1),
       ('B',9),
       ('C',7),
       ('D',8),
       ('E',2),
	   ('F',3),
       ('G',4),
       ('H',5),
       ('I',10),
       ('J',6)

INSERT INTO TipoProveedor(nombre,idProveedor)
VALUES ('Aceites y Quimicos',7),
	   ('Piezas de motor',2),
	   ('Piezas en general',3),
	   ('Partes exteriores',1),
	   ('Partes interiores',4)

INSERT INTO Venta(fecha,monto,descripcion,idFormaPago,idFactura)
VALUES (getdate(),556,'Venta de 8 bujias y un filtro de aceite para motor',1,7),
	   (getdate(),1892,'Venta de Aceite para Motor',2,6),
	   (getdate(),800,'Venta de Bateria',1,8),
	   (getdate(),1204,'Venta de carburador de motor',1,9),
	   (getdate(),500,'Venta de banda para motor',3,2),
	   (getdate(),2155,'Venta de Amortiguador',1,3),
	   (getdate(),450,'Venta de filtro de gasolina',1,1),
	   (getdate(),100,'Venta de 4 llantas',2,5),
	   (getdate(),300,'Venta de 2 Balatas',1,4)

INSERT INTO TipoAsentamiento(nombre)-------ERROOR
VALUES ('Rancheria'),
       ('Residencia'),
       ('Colonia'),
       ('Pueblo'),
       ('Barrio'),
	   ('Fraccionamiento'),
       ('Ejido'),
       ('Zona industrial'),
       ('Unidad habitacional'),
       ('Equipamiento')


INSERT INTO Asentamiento(codigoPostal,nombre,idMunicipio,idTipoAsentamiento)
VALUES ('25736','Puerto blanco',34,3),
       ('25740','Tierra y Libertad',34,3),
       ('25740','Emiliano Zapata',34,3),
       ('25749','Flores',34,3),
       ('25743','Borjas',34,3),
	   ('25730','Arturias',34,3),
       ('25742','Estancias',34,3),
       ('25745','Rivera',34,3),
       ('25746','Del Rio',34,3),
       ('24740','Centro',34,3)

INSERT INTO AutoParte(descripcion,precio,idMarca,idTipoAutoparte)
VALUES  ('Capó',1000,1,2),
        ('Guardafango',800,1,2),
        ('Puerta Delantera',3000,2,2),
        ('Parabrisas delantero',200,3,2),
        ('Silla delantera',1500,1,1),
        ('Costado',1000,2,2),
        ('Stop',300,1,2),
        ('Tapa baúl',500,2,2),
        ('Paragolpes trasero',300,3,2),
        ('Panel trasero',250,5,2),
        ('Parabrisas trasero',200,6,2),
        ('Capota',6000,2,1),
        ('Consola central',500,3,1),
        ('Timón',900,2,1),
        ('Tablero de instrumentos',1650,1,1),
        ('Espejo interior',250,2,1),
        ('Espejo exterior',250,2,2),
        ('Farola o unidad delantera',300,5,2),
        ('Luz antiniebla',200,6,2),
        ('Paragolpes delantero',700,1,2),
        ('Vidrio puerta delantera',2500,1,2),
        ('Vidrio puerta trasera',2500,1,2),
        ('Puerta trasera',3000,4,2),
        ('llanta',100,3,2),
	    ('Rin',1500,3,2),
	    ('Cremallera',2000,2,3),
	    ('Transmicion',6000,2,3),
	    ('Motor',12000,3,3),
	    ('Asiento',1500,1,1),
	    ('Radiador',800,3,3),
	    ('Volante',1000,5,1)


INSERT INTO Compra(fecha,monto,detalles,idFormaPago,idFactura)
VALUES (getdate(),556,'Compra de 8 bujias y un filtro de aceite para motor',1,7),
	   (getdate(),1892,'Compra de Aceite para Motor',2,6),
	   (getdate(),800,'Compra de Bateria',1,8),
	   (getdate(),1204,'Compra de carburador de motor',1,9),
	   (getdate(),500,'Compra de banda para motor',3,2),
	   (getdate(),2155,'Compra de Amortiguador',1,3),
	   (getdate(),450,'Compra de filtro de gasolina',1,1),
	   (getdate(),100,'Compra de 4 llantas',2,5),
	   (getdate(),300,'Compra de 2 Balatas',1,4)

INSERT INTO Descuento(fechalimite,monto,detalles,idVenta)
VALUES ('2022-06-01','20 %','Descuento en todos los aceites',2),
	   ('2022-07-06','10 %','Descuento en la compra de mas de 4 bujias',1),
	   ('2022-06-06','5 %','Descuento en banterias de auto',3),
	   ('2022-07-15','10 %','Descuento en carburadores',4),
	   ('2022-06-20','5 %','Descuento en bandas para motor',5),
	   ('2022-06-26','15 %','Dscuento en amortiguadores',6),
	   ('2022-07-16','20 %','Descuento en filtrso de gasolina',7),
	   ('2022-06-01','10 %','Descuento en llantas',8),
	   ('2022-07-10','10 %','Descuento en balatas',9)

---------------------------------------------------------------------------------------------
INSERT INTO AutoparteSucursal(idAutoparte,idSucursal)
VALUES (1,1),
       (2,2),
	   (3,3)

INSERT INTO ClienteCompra(idCliente,idCompra)
VALUES (1,1),
       (2,2),
	   (3,3),
	   (4,4),
	   (5,5),
	   (6,6),
	   (7,7),
	   (8,8),
	   (9,9)

INSERT INTO ClienteProducto(idCliente,idProducto)
VALUES (1,1),
       (1,1),
	   (1,1),
	   (1,1),
	   (1,1),
	   (1,1),
	   (1,1),
	   (1,1)
 
INSERT INTO ClienteSucursal(idCliente,idSucursal)
VALUES (1,1),
       (2,2),
	   (3,3),
	   (4,3),
	   (5,3),
	   (6,2),
	   (7,2),
	   (8,2),
	   (9,1)

INSERT INTO EmpleadoProducto(idEmpleado,idProducto)
VALUES (1,3),
       (2,7),
	   (3,6),
	   (4,4),
	   (5,5),
	   (6,1),
	   (7,8),
	   (8,11),
	   (9,10),
	   (10,9)

INSERT INTO ProductoCompra(idProducto,idCompra)
VALUES (6,1),
       (19,2),
	   (5,3),
	   (4,4),
	   (15,5),
	   (17,6),
	   (3,7),
/**/   (20,8),
	   (13,9)
	   

INSERT INTO QuimicosSucursal(idQuimicos,idSucursal)
VALUES (1,1),
       (2,1),
	   (3,1),
	   (4,1),
	   (5,1),
	   (6,1)

INSERT INTO SucursalAccesorio(idSucursal,idAccesorio)
VALUES (1,1),
       (2,2),
	   (3,3),
	   (1,4)

INSERT INTO SucursalEmpleado(idSucursal,idEmpleado,fechaIngreso)
VALUES (1,1,'2013-05-12'),
       (1,2,'2016-08-02'),
	   (1,3,'2010-02-15'),
	   (1,4,'2012-06-02'),
	   (1,5,'2017-01-24'),
	   (1,6,'2018-02-20'),
	   (1,7,'2011-03-22'),
	   (1,8,'2019-02-02'),
	   (1,9,'2020-07-02'),
	   (1,10,'2010-09-02')

INSERT INTO SucursalEquipoComputo(idSucursal,idEquipoComputo)
VALUES (1,1),
	   (1,1),
	   (1,1),
	   (1,1),
	   (1,1),
	   (1,1)

INSERT INTO SucursalEstado(idSucursal,idEstado)
VALUES (1,8),
       (2,8),
	   (3,8)

INSERT INTO SucursalMoviliario(idSucursal,idMoviliario)
VALUES (1,1),
       (2,1),
	   (3,1)
       

INSERT INTO SucursalProveedor(idSucursal,idProveedor)
VALUES (1,3),
	   (2,5),
	   (1,6),
	   (2,1),
	   (3,2),
	   (1,4),
	   (1,7)

INSERT INTO SucursalPublicidad(idSucursal,idPublicidad)
VALUES (1,1),
       (2,9),
	   (1,7),
	   (3,8),
	   (2,2),
	   (1,10),
	   (1,4),
	   (1,3),
	   (1,8)

INSERT INTO TipoAsentamientoZona(idTipoAsentamiento,idZona)
VALUES (1,2),
       (2,1),
	   (3,1),
	   (4,1),
	   (5,1),
	   (6,1),
	   (7,2),
	   (8,1),
	   (9,1),
	   (10,1)

INSERT INTO VentaEmpleado(idVenta,idEmpleado)
VALUES (1,1),
       (2,2),
       (3,3),
       (4,4),
       (5,5),
       (6,6),
       (7,7),
	   (8,8),
       (9,9)
       
INSERT INTO ProductoVenta(idProducto,idVenta)
VALUES (6,1),
       (19,2),
	   (5,3),
	   (4,4),
	   (15,5),
	   (17,6),
	   (3,7),
	   (1,8),
	   (13,9)