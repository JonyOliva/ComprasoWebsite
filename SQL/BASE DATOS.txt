-- CREACION DE BASE --

USE MASTER 
GO

CREATE DATABASE BD_COMPRASO
GO

USE BD_COMPRASO
GO

CREATE TABLE USUARIOS
(
IDUsuario char(4),
Admin_USU bit NOT NULL,
Nombre_USU char(30) NOT NULL,
Apellido_USU char(40) NOT NULL,
DNI_USU char(9) NOT NULL,
Email_USU char(60) UNIQUE NOT NULL,
nroCel_USU char(12),
FechaNac_USU date NOT NULL,
CONSTRAINT PK_USUARIOS PRIMARY KEY (IDUsuario)
)
GO

CREATE TABLE DirecxUsuario
(
IDUsuario_DIR char(4) NOT NULL,
CodDirreccion smallint IDENTITY(1,1),
Provincia_DIR char(40) NOT NULL,
Direccion_DIR char(40),
CONSTRAINT PK_DirxUs PRIMARY KEY (IDUsuario_DIR, CodDirreccion),
CONSTRAINT FK_DirxUs FOREIGN KEY (IDUsuario_DIR) REFERENCES USUARIOS (IDUsuario)
)
GO

CREATE TABLE ENVIOS
(
IDEnvio char(2),
Costo_ENVIO smallmoney NOT NULL,
Tiempo_ENVIO tinyint NOT NULL,
Provincia_ENVIO char(40) NOT NULL,
CONSTRAINT PK_Envios PRIMARY KEY (IDEnvio)
)
GO

CREATE TABLE VENTAS
(
IDVenta int IDENTITY(1,1),
NroTarjeta_VENTA char(16) NOT NULL, 
IDUsuario_VENTA char(4) NOT NULL,
CodDirreccion_VENTA smallint NOT NULL,
Descuento_VENTA float,
Total_VENTA money NOT NULL,
IDEnvio_VENTA char(2) REFERENCES ENVIOS (IDEnvio),
Estado tinyint NOT NULL,
CONSTRAINT PK_Ventas PRIMARY KEY (IDVenta)
)
GO

CREATE TABLE CATEGORIAS
(
IDCategoria char(4) PRIMARY KEY,
Nombre_CAT char(20) NOT NULL,
)
GO

CREATE TABLE SUBCATEGORIAS
(
IDSubCategoria char(4),
IDCategoria_SUBCAT char(4),
Nombre_SUBCAT char(20) NOT NULL,
CONSTRAINT PK_SubCat PRIMARY KEY (IDSubCategoria, IDCategoria_SUBCAT),
CONSTRAINT FK_SubCat FOREIGN KEY (IDCategoria_SUBCAT) REFERENCES CATEGORIAS (IDCategoria)
)
GO

CREATE TABLE MARCAS
(
IDMarca char(4) PRIMARY KEY,
Nombre_MARCA char(20) NOT NULL,
)
GO

CREATE TABLE PRODUCTOS
(
IDProducto char(4),
Nombre_PROD char(30) NOT NULL,
IDCategoria_PROD char(4) NOT NULL,
IDSubCategoria_PROD char(4) NOT NULL,
IDMarca_PROD char(4) REFERENCES MARCAS (IDMarca) NOT NULL,
Descripcion_PROD char(1000),
Stock_PROD int NOT NULL,
Precio_PROD money NOT NULL,
Descuento_PROD float,
RutaImagen char(200) NOT NULL,
ACTIVO bit,
CONSTRAINT PK_Produc PRIMARY KEY (IDProducto),
CONSTRAINT FK_Produc FOREIGN KEY (IDSubCategoria_PROD, IDCategoria_PROD) REFERENCES SUBCATEGORIAS (IDSubCategoria, IDCategoria_SUBCAT),
CONSTRAINT CHK_Stock CHECK (Stock_PROD >= 0)
)
GO

CREATE TABLE DETVENTAS
(
IDVenta_DETV char(4),
IDProducto_DETV char(4),
Descuento_DETV float,
Cantidad_DETV int CHECK (Cantidad_DETV>=1) NOT NULL,
PrecioUnitario_DETV money NOT NULL,
CONSTRAINT PK_DetVentas PRIMARY KEY (IDVenta_DETV, IDProducto_DETV)
)
GO

CREATE TABLE CUOTAS
(
IDCuota_CUO char(4),
Cantidad_CUO tinyint NOT NULL,
Interes_CUO float,
CONSTRAINT PK_Cuotas PRIMARY KEY (IDCuota_CUO)
)
GO

CREATE TABLE TARJETAS
(
IDTarjeta_TARJ char(4),
Nombre_TARJ char(20) NOT NULL,
--IDCuotas_TARJ char(4),
CONSTRAINT PK_Tarjetas PRIMARY KEY (IDTarjeta_TARJ),
)
GO

CREATE TABLE CuotasxTarjetas
(
IDTarjeta_CxT char(4),
IDCuota_CxT char(4),
CONSTRAINT PK_CxT PRIMARY KEY (IDTarjeta_CxT, IDCuota_CxT),
--CONSTRAINT FK_CxT FOREIGN KEY(IDTARJETA_CxT) REFERENCES TARJETAS(IDTarjeta_TARJ),
CONSTRAINT FK_CuotasxT FOREIGN KEY (IDCuota_CxT) REFERENCES CUOTAS (IDCuota_CUO)
)
GO

CREATE TABLE TarjetasxUsuario
(
IDUsuario_TxU char(4) NOT NULL,
NroTarjeta char(16) NOT NULL,
IDTarjeta_TxU char(4) NOT NULL,
Titular char(30) NOT NULL,
Vencimiento date NOT NULL,
CONSTRAINT PK_TxU PRIMARY KEY (NroTarjeta),
CONSTRAINT FK_TxU FOREIGN KEY (IDTarjeta_TxU) REFERENCES TARJETAS (IDTarjeta_TARJ)
)
GO


--alter table CuotasxTarjetas
--add CONSTRAINT FK_CxTarj FOREIGN KEY(IDTARJETA_CxT) REFERENCES TARJETAS(IDTarjeta_TARJ)



--   FIN TABLAS --




--  INSERTS ---


INSERT INTO MARCAS(IDMarca, Nombre_MARCA)
VALUES('M001', 'ARVO'),('M002', 'SAMSUNG'),('M003','SONY')

INSERT INTO CATEGORIAS(IDCategoria, Nombre_CAT)
VALUES ('C001','TELEVISORES'),('C002',''),('C003','')

INSERT INTO SUBCATEGORIAS(IDSubCategoria, IDCategoria_SUBCAT,Nombre_SUBCAT)
VALUES ('S001','C001','LED Y SMART TV') --,('S002','',''),('S003','','')

INSERT INTO PRODUCTOS(IDProducto, Nombre_PROD, IDCategoria_PROD, IDSubCategoria_PROD, IDMarca_PROD, Descripcion_PROD, Stock_PROD, Precio_PROD, Descuento_PROD, RutaImagen, ACTIVO)
VALUES ('P001','SMART TV 32" ARVO','C001','S001','M001',
'El TELEVISOR 32" SMART TV  de ARVO cuenta con una pantalla widescreen (16:9) con resolución HD (1366x768). La tecnología LED no sólo reduce el consumo de energía sino que aporta una gran calidad de imagen y contraste.
Para poder disfrutar al máximo de la mejor calidad y definición de imagen se deben respetar las indicaciones recomendadas de distancia óptima desde el televisor al televidente.',
3,8999.99,0,'~/ArvoProjectWebsite/Assets/Images/SMARTTV-ARVO32',1)

INSERT INTO CUOTAS(IDCuota_CUO, Cantidad_CUO, Interes_CUO)
VALUES('001C',1,0),('002C',3,1.25)

INSERT INTO TARJETAS(IDTarjeta_TARJ,Nombre_TARJ)
VALUES('T001','ARVOCARD')

INSERT INTO CuotasxTarjetas(IDTarjeta_CxT,IDCuota_CxT)
VALUES ('T001','001C'),('T001','002C')

INSERT INTO ENVIOS(IDEnvio, Costo_ENVIO, Tiempo_ENVIO, Provincia_ENVIO)
VALUES ('01',100,24,'CABA'),('02',150,24,'GBA'),('03',165,36,'BUENOS AIRES')

INSERT INTO USUARIOS(IDUsuario,Admin_USU,Nombre_USU,Apellido_USU,DNI_USU,Email_USU,nroCel_USU,FechaNac_USU)
VALUES('0000',1,'CLAUDIO','CLAUDIO','000000001','CLAUDIO@ARVO.CF','111111111','01/01/1000')

INSERT INTO DirecxUsuario(IDUsuario_DIR,Provincia_DIR,Direccion_DIR)
VALUES('0000','CABA','9 DE JULIO 123')

INSERT INTO TarjetasxUsuario(IDUsuario_TxU,NroTarjeta,IDTarjeta_TxU,Titular,Vencimiento)
VALUES('0000','0000000000000000','T001','CLAUDIO','01/01/2020')


INSERT INTO VENTAS(NroTarjeta_VENTA, IDUsuario_VENTA, CodDirreccion_VENTA, Descuento_VENTA, Total_VENTA, IDEnvio_VENTA, EstadoEnvio)
VALUES('000000000000000','0000','1',0,9099.99,'01','1')

INSERT INTO DETVENTAS(IDVenta_DETV,IDProducto_DETV,Descuento_DETV,Cantidad_DETV,PrecioUnitario_DETV)
VALUES(1,'P001',0,1,8999.99)