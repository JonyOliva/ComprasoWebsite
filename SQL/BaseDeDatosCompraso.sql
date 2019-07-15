-- CREACION DE BASE --

USE MASTER 
GO

CREATE DATABASE BD_COMPRASO
GO

USE BD_COMPRASO
GO

CREATE TABLE USUARIOS
(
IDUsuario char(12),
Admin_USU bit NOT NULL,
Nombre_USU char(30) NOT NULL,
Apellido_USU char(40) NOT NULL,
DNI_USU char(9) NOT NULL,
Email_USU char(60) UNIQUE NOT NULL,
Password_USU char(15) NOT NULL,
nroCel_USU char(12),
FechaNac_USU date NOT NULL,
CONSTRAINT PK_USUARIOS PRIMARY KEY (IDUsuario)
)
GO

CREATE TABLE DirecxUsuario
(
IDUsuario_DIR char(12) NOT NULL,
CodDirreccion smallint IDENTITY(1,1),
Provincia_DIR char(40) NOT NULL,
Direccion_DIR char(40),
Activo_DIR bit NOT NULL,
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
IDUsuario_VENTA char(12) NOT NULL,
CodDirreccion_VENTA smallint NOT NULL,
Descuento_VENTA float,
Total_VENTA money NOT NULL,
IDEnvio_VENTA char(2) REFERENCES ENVIOS (IDEnvio),
Fecha_VENTA date NOT NULL,
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
Nombre_SUBCAT char(40) NOT NULL,
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
IDVenta_DETV int,
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
IDCuotas_TARJ char(4),
CONSTRAINT PK_Tarjetas PRIMARY KEY (IDTarjeta_TARJ),
)
GO

CREATE TABLE CuotasxTarjetas
(
IDTarjeta_CxT char(4),
IDCuota_CxT char(4),
CONSTRAINT PK_CxT PRIMARY KEY (IDTarjeta_CxT, IDCuota_CxT),
CONSTRAINT FK_CuotasxT FOREIGN KEY (IDCuota_CxT) REFERENCES CUOTAS (IDCuota_CUO)
)
GO

CREATE TABLE TarjetasxUsuario
(
IDUsuario_TxU char(12) NOT NULL,
NroTarjeta char(16) NOT NULL,
IDTarjeta_TxU char(4) NOT NULL,
Titular char(30) NOT NULL,
Vencimiento date NOT NULL,
Activo_TxU bit NOT NULL,
CONSTRAINT PK_TxU PRIMARY KEY (NroTarjeta),
CONSTRAINT FK_TxU FOREIGN KEY (IDTarjeta_TxU) REFERENCES TARJETAS (IDTarjeta_TARJ)
)
GO

alter table CuotasxTarjetas
add CONSTRAINT FK_CxTarj FOREIGN KEY(IDTARJETA_CxT) REFERENCES TARJETAS(IDTarjeta_TARJ)


--   FIN TABLAS --




-----------------INSERTS-------------------


INSERT INTO MARCAS(IDMarca, Nombre_MARCA)
SELECT 'M001', 'ARVO' UNION
SELECT 'M002', 'Samsung' UNION
SELECT 'M003','Sony' UNION
SELECT 'M004','Philips' UNION
SELECT 'M005','Bangho' UNION
SELECT 'M006','Epson' UNION
SELECT 'M007','Motorola' UNION
SELECT 'M008','Drean' UNION
SELECT 'M009','Garden Life' UNION
SELECT 'M010','Bram-Metal' UNION
SELECT 'M011','Philco' UNION
SELECT 'M012','ION' 

INSERT INTO CATEGORIAS(IDCategoria, Nombre_CAT)
SELECT 'C001','Informatica' UNION
SELECT 'C002','Tv, Audio y Video' UNION
SELECT 'C003','Electrodomesticos' UNION
SELECT 'C004', 'Celulares y Tablets' UNION
SELECT 'C005', 'Casa y Jardin'

INSERT INTO SUBCATEGORIAS(IDSubCategoria, IDCategoria_SUBCAT,Nombre_SUBCAT)
SELECT 'S001','C001','Notebooks' UNION
SELECT 'S002','C001','PCs' UNION
SELECT 'S003','C001','Impresoras y Cartuchos' UNION
SELECT 'S004','C001','Accesorios' UNION	

SELECT 'S005','C002','Televisores' UNION
SELECT 'S006','C002','Audio' UNION
SELECT 'S007','C002','Consolas' UNION
SELECT 'S008','C002','Accesorios' UNION

SELECT 'S009','C003','Pequeño electro' UNION 
SELECT 'S010','C003','Heladeras' UNION
SELECT 'S011','C003','Cocinas' UNION
SELECT 'S012','C003','Lavarropas' UNION

SELECT 'S013','C004','Celulares' UNION
SELECT 'S014','C004','Tablets' UNION
SELECT 'S015','C004','Accesorios' UNION

SELECT 'S016','C005','Máquinas de jardín' UNION
SELECT 'S017','C005','Deportes' UNION 
SELECT 'S018','C005','Muebles'


INSERT INTO CUOTAS(IDCuota_CUO, Cantidad_CUO, Interes_CUO)
SELECT '001C', 1, 0 UNION
SELECT '002C', 3, 1.25 UNION
SELECT '003C', 6, 1.5 UNION
SELECT '004C', 12, 1.7 UNION
SELECT '005C', 18, 2 UNION
SELECT '006C', 6, 1.4 UNION
SELECT '007C', 12, 1.6 UNION
SELECT '008C', 18, 2 UNION
SELECT '009C', 3, 1.25 UNION
SELECT '010C', 6, 1.6 UNION
SELECT '011C', 12, 2 UNION
SELECT '012C', 18, 2.2 UNION
SELECT '013C', 3, 1.3 UNION
SELECT '014C', 6, 1.45 UNION
SELECT '015C', 12, 1.8 UNION
SELECT '016C', 18, 2.3

INSERT INTO TARJETAS(IDTarjeta_TARJ,Nombre_TARJ)
SELECT 'T001', 'ARVOCARD' UNION
SELECT 'T002', 'VISA' UNION
SELECT 'T003', 'MASTERCARD' UNION
SELECT 'T004', 'AMERICAN EXPRESS' UNION
SELECT 'T005', 'DINERS CLUB'


INSERT INTO CuotasxTarjetas(IDTarjeta_CxT,IDCuota_CxT)
SELECT 'T001', '001C' UNION
SELECT 'T001', '002C' UNION
SELECT 'T001', '003C' UNION
SELECT 'T001', '004C' UNION
SELECT 'T001', '005C' UNION
SELECT 'T002', '001C' UNION
SELECT 'T002', '002C' UNION
SELECT 'T002', '006C' UNION
SELECT 'T002', '007C' UNION
SELECT 'T002', '008C' UNION
SELECT 'T003', '001C' UNION
SELECT 'T003', '009C' UNION
SELECT 'T003', '010C' UNION
SELECT 'T003', '011C' UNION
SELECT 'T003', '012C' UNION
SELECT 'T004', '001C' UNION
SELECT 'T004', '013C' UNION
SELECT 'T004', '014C' UNION
SELECT 'T004', '011C' UNION
SELECT 'T004', '016C' UNION
SELECT 'T005', '001C' UNION
SELECT 'T005', '013C' UNION
SELECT 'T005', '014C' UNION
SELECT 'T005', '015C' UNION
SELECT 'T005', '016C' 

INSERT INTO ENVIOS(IDEnvio, Costo_ENVIO, Tiempo_ENVIO, Provincia_ENVIO)
SELECT '01', 100, 24, 'CABA' UNION
SELECT '02', 150, 24, 'GBA' UNION
SELECT '03', 165, 36, 'BUENOS AIRES' UNION
SELECT '04', 235, 48, 'CATAMARCA' UNION
SELECT '05', 300, 48, 'CHACO' UNION
SELECT '06', 260, 36, 'CHUBUT' UNION
SELECT '07', 200, 24, 'CORDOBA' UNION
SELECT '08', 300, 48, 'CORRIENTES' UNION
SELECT '09', 200, 24, 'ENTRE RIOS' UNION
SELECT '10', 300, 36, 'FORMOSA' UNION
SELECT '11', 350, 60, 'JUJUY' UNION
SELECT '12', 250, 24, 'LA PAMPA' UNION
SELECT '13', 300, 36, 'LA RIOJA' UNION
SELECT '14', 250, 24, 'MENDOZA' UNION
SELECT '15', 300, 48, 'MISIONES' UNION
SELECT '16', 300, 48, 'NEUQUEN' UNION
SELECT '17', 250, 36, 'RIO NEGRO' UNION
SELECT '18', 350, 60, 'SALTA' UNION
SELECT '19', 300, 48, 'SAN JUAN' UNION
SELECT '20', 350, 48, 'SANTA CRUZ' UNION
SELECT '21', 250, 36, 'SANTA FE' UNION
SELECT '22', 300, 48, 'SANTIAGO DEL ESTERO' UNION
SELECT '23', 350, 72, 'TIERRA DEL FUEGO' UNION
SELECT '24', '300', 48, 'TUCUMAN'

INSERT INTO USUARIOS(IDUsuario,Password_USU, Admin_USU,Nombre_USU,Apellido_USU,DNI_USU,Email_USU,nroCel_USU,FechaNac_USU)
SELECT '0000','123456', 1,'CLAUDIO','CLAUDIO','000000001','CLAUDIO@ARVO.CF','111111111','01/01/1000'

INSERT INTO DirecxUsuario(IDUsuario_DIR,Provincia_DIR,Direccion_DIR, Activo_DIR)
SELECT '0000','CABA','9 DE JULIO 123',1

INSERT INTO TarjetasxUsuario(IDUsuario_TxU,NroTarjeta,IDTarjeta_TxU,Titular,Vencimiento, Activo_TxU)
SELECT '0000','0000000000000000','T001','CLAUDIO','01/01/2020',1


INSERT INTO VENTAS(NroTarjeta_VENTA, IDUsuario_VENTA, CodDirreccion_VENTA, Descuento_VENTA, Total_VENTA, IDEnvio_VENTA, Fecha_VENTA, Estado)
SELECT '000000000000000','0000','1',0,9099.99,'01',getdate(),2 UNION
SELECT '046865432300334','0000','1',0,35698,'01',getdate(),2 UNION
SELECT '000000000000000','0000','1',0,45678,'01','2019-10-10',2 UNION
SELECT '046865432300334','0000','1',0,3556,'01','2019-6-8',2 UNION
SELECT '000000000000000','0000','1',0,1200,'01','2019-2-8',2 UNION
SELECT '046865432300334','0000','1',0,3221,'01','2019-3-5',2

INSERT INTO DETVENTAS(IDVenta_DETV,IDProducto_DETV,Descuento_DETV,Cantidad_DETV,PrecioUnitario_DETV)
SELECT 1,'P001',0,3,8999.99 UNION
SELECT 1,'P003',0,5,14000 UNION
SELECT 2,'P001',0,3,6325 UNION
SELECT 2,'P008',0,2,20145 UNION
SELECT 2,'P005',0,8,8700 UNION
SELECT 2,'P004',0,4,6988 UNION
SELECT 3,'P004',0,2,7894 UNION
SELECT 4,'P005',0,3,4547 UNION
SELECT 5,'P007',0,4,100 UNION
SELECT 3,'P009',0,2,12000 UNION
SELECT 4,'P012',0,3,8700 UNION
SELECT 6,'P003',0,1,9500

INSERT INTO PRODUCTOS(IDProducto, Nombre_PROD, IDCategoria_PROD, IDSubCategoria_PROD, IDMarca_PROD, Descripcion_PROD, Stock_PROD, Precio_PROD, Descuento_PROD, RutaImagen, ACTIVO)
SELECT 'P001','Smart TV 32"','C002','S005','M001',
'El TELEVISOR 32" SMART TV  de ARVO cuenta con una pantalla widescreen (16:9) con resolución HD (1366x768). La tecnología LED no sólo reduce el consumo de energía sino que aporta una gran calidad de imagen y contraste.
Para poder disfrutar al máximo de la mejor calidad y definición de imagen se deben respetar las indicaciones recomendadas de distancia óptima desde el televisor al televidente.',
3,8999,0,'~/Assets/Images/P001.jpg',1 UNION

SELECT 'P002','Notebook 15.6" CORE I3','C001','S001','M005',
'La notebook Bangho G5-i3 tiene un diseño muy sólido y por otro lado, cuenta con un práctico teclado numérico.
Su pantalla LCD TFT de 15,6 pulgadas y resolución HD (1366 x 768 pixeles) te permitirá acceder a internet y disfrutar de películas y juegos con una gran definición.
Su procesador Intel Core i3 7100U y su memoria RAM de 4GB se complementan para ofrecer el máximo rendimiento con un bajo consumo de energía.',
6,34999,10,'~/Assets/Images/P002.jpg',1 UNION

SELECT 'P003','Impresora Multifunción','C001','S003','M006',
'Con la impresora multifunción Epson DCPT710W vas a poder imprimir, escanear y copiar, documentos y fotos en forma rápida con colores vibrantes y textos nítidos. Además vas a poder ahorrar espacio, gracias a su diseño ultra compacto que encaja prácticamente en cualquier espacio.',
21,13499,5,'~/Assets/Images/P003.jpg',1 UNION

SELECT 'P004','Samsung Galaxy J6 Plus','C004','S013','M002',
'El celular Galaxy J6 Plus se caracteriza por un diseño robusto y estilizado, además de cómodo y atractivo. A través de su pantalla touch TFT LCD de 6 pulgadas de resolución HD (1480x720), vas a poder comunicarte y divertirte.
 Su batería de 3300 mAh te garantiza muchas horas de uso: disfrutá alrededor de 23 horas de conversación.',
9,14999,0,'~/Assets/Images/P004.jpg',1 UNION

SELECT 'P005','Led 42" Full HD','C002','S005','M004',
'El LED TV Philips 42 pulgadas cuenta con una pantalla de visualización LED de 106 cm, formato Widescreen (16:9) y una resolución de 1920 x 1080 píxeles. A diferencia del estándar HD, su alto nivel de detalle brinda colores más puros y nítidos.',
10,13999,0,'~/Assets/Images/P005.jpg',1 UNION

SELECT 'P006','Auriculares in ear negro','C002','S006','M007',
'Los auriculares SHE1405BK/10 cuenta con un diseño compacto y moderno para que puedas llevarlos a donde quieras. A su vez, el ajuste perfecto que posee sella el canal instructivo para bloquear los ruidos externos. Más, 3 accesorios de goma intercambiables que se adaptan a todas las orejas. El protector de goma para el cable te asegura más durabilidad.',
22,399,0,'~/Assets/Images/P006.jpg',1 UNION

SELECT 'P007','Auriculares Bluetooth Pulse','C002','S006','M004',
'Los auriculares inalámbricos Pulse Escape de Motorola poseen un diseño con orejeras plegables que facilitan su guardado y transporte. Cuentan con tecnología Bluetooth 4.1 para usarlos de forma inalámbrica o bien, del modo convencional con el cable plug-plug incluido en la caja.',
13,3199,5,'~/Assets/Images/P007.jpg',1 UNION

SELECT 'P008','Auriculares inalámbricos','C002','S006','M003',
'Ligeros y ergonómicos, los auriculares Sony WH-CH500 pueden plegarse mientras no se usan. Cuando los lleves puestos, la comodidad de las almohadillas te permitirán usarlos todo el día sin detener tu ritmo de vida.',
7,4999,0,'~/Assets/Images/P008.jpg',1 UNION

SELECT 'P009','Consola PS4 Slim 1TB + juegos','C002','S007','M003',
'Consola PS4 SLIM 1TB + DAYS GONE + DETROIT + RAINBOW SIX SIEGE
La PS4 presenta un elegante diseño y cuenta con nuevos detalles como los botones táctiles de encendido o eject que no se ven a simple vista. Es más ligera y más delgada que el modelo original, y también puede colocarse en forma vertical, con un soporte que se vende por separado. Gracias a su disco rígido de 1TB, en la PS4 vas a poder guardar juegos, capturas de pantallas y videos.',
5,29999,5,'~/Assets/Images/P009.jpg',1 UNION

SELECT 'P010','Joystick Dualshock 4','C002','S008','M003',
'El Dualshock 4 wireless presenta mejoras en cuanto a su capacidad de respuesta y la comodidad de sus componentes. Entre sus novedades, presenta un sensor de seis ejes a través del cual podrás tener experiencias de juego más realistas, mientras que el panel táctil ubicado en la parte superior del control ofrece nuevas formas de jugar e interactuar.',
4,3799,10,'~/Assets/Images/P010.jpg',1 UNION

SELECT 'P011','Lavarropas carga frontal 6 KG','C003','S012','M008',
'El lavarropas de carga frontal Drean Next 6.06 está especialmente diseñado para mejorar toda la experiencia de lavado de ropa. Con una puerta de acceso frontal de tamaño extra grande, colocar las prendas es muy fácil.El Drean viene con 29 combinaciones de lavado para todo tipo de telas. Además, cuenta con función antiarrugas; lavado rápido y Hand Wash, que simula un lavado a mano cuidando especialmente la ropa con un sistema lento y suave.',
14,19999,15,'~/Assets/Images/P011.jpg',1 UNION

SELECT 'P012','Heladera no Frost Inverter','C003','S010','M002',
'La heladera Samsung RT32K5930 tiene un diseño fino e innovador que combina en cualquier tipo de cocina. En su interior, cuenta con estantes de vidrio templado y un amplio cajón para frutas y verduras. Su capacidad de almacenamiento es de 321 litros y su clasificación de eficiencia energética es clase A+, lo que significa que su consumo de energía es restringido y ayuda en el cuidado del medio ambiente.',
3,47499,20,'~/Assets/Images/P012.jpg',1 UNION

SELECT 'P013','Juego de jardín puket','C005','S018','M009',
'Juego de jardín puket, 2 sillas miame negras. Este juego de jardín está compuesto por dos sillas individuales Miami con respaldo ergonómico y una mesa auxiliar Puket.
Ambos modelos tienen una textura simil madera y están elaborados en un plástico muy fácil de limpiar. Además, son resistentes a los rayos UV y están diseñados para no dañar el ambiente. Asimismo, la silla Miami soporta 120 kg.',
8,4999,30,'~/Assets/Images/P013.jpg',1 UNION

SELECT 'P014','Parrilla a carbon metal','C005','S018','M010',
'Parrilla a Carbón Modelo Algarrobo. Ventilación de acero inoxidable, resistente a la corrosión. Asa en la tapa. Patas reforzadas y con ruedas. Parrilla de cocción doble, con estante superior, brinda mayor superficie. Parrilla de acero niquelado con bisagra reforzada. Fácil de limpiar. Doble mesada de madera (frontal y lateral)',
5,16559,20,'~/Assets/Images/P014.jpg',1 UNION

SELECT 'P015','Combo reposeras maceio','C005','S018','M009',
'Las reposeras Maceio de Garden Life cuentan con 5 posiciones de reclinado, incluso hasta un ángulo de 180 grados (posición acostado). Están elaboradas en material plástico, resistente a los cambios climáticos y muy fáciles de limpiar. 
Es el combo incluye 2 unidades y es ideal para disfrutar del sol este verano.
Cada reposera soporta hasta 200 kg.',
11,11199,10,'~/Assets/Images/P015.jpg',1 UNION

SELECT 'P016','Bicicleta Mountain bike 26"','C005','S017','M011',
'La bicicleta Mountain Bike Vertical rodado 26" Philco viene con cuadro de acero, 21 velocidades Shimano, doble suspensión, freno tipo disco mecánico y llantas de doble pared.',
3,16999,25,'~/Assets/Images/P016.jpg',1 UNION

SELECT 'P017','Skate eléctrico negro','C005','S017','M012',
'El Skateboard ION fue diseñado con el estilo clásico y retro de los primeros skateboards de la década del 70, incluyendo la innovación tecnológica que necesitaba para convertirlo en la mejor patineta de todos los tiempos. Cuenta con batería de litio LG que le brinda hasta 10km de autonomía a una velocidad de 18km/h, y con un control remoto que permite direccionar el skate hacia donde quieras llevarlo.',
7,10999,0,'~/Assets/Images/P017.jpg',1 

GO

-------------STORED PROCEDURES-------------

--PRODUCTOS

CREATE PROCEDURE spObtenerMarcas
(
@IDSubCat char(4),
@IDCat char(4)
)
AS
SELECT DISTINCT IDMarca, Nombre_MARCA FROM PRODUCTOS INNER JOIN MARCAS
ON IDMarca_PROD=IDMarca WHERE (IDCategoria_PROD=@IDCat AND IDSubCategoria_PROD=@IDSubCat)
GO

CREATE PROCEDURE Buscador
(
@aBuscar char(15)
)
AS
SELECT IDCategoria_PROD,IDSubCategoria_PROD FROM PRODUCTOS 
WHERE (Nombre_PROD LIKE '%' + rtrim(@aBuscar) + '%') 
OR (Descripcion_PROD LIKE '%' + rtrim(@aBuscar) + '%')
GO

CREATE PROCEDURE spFiltrarProductos
(
@Nombre char(30),
@IDCategoria char(4),
@IDSubCategoria char(4),
@IDMarca char(4),
@Descuento float
)
AS
SELECT IDProducto, Nombre_PROD FROM PRODUCTOS WHERE
(ACTIVO = 1)
AND
((@Nombre is null) or (Nombre_PROD LIKE '%' + rtrim(@Nombre) + '%'))
AND
((@IDCategoria is null) or (@IDCategoria=IDCategoria_PROD))
AND
((@IDSubCategoria is null) or (@IDSubCategoria=IDSubCategoria_PROD))
AND
((@IDMarca is null) or (@IDMarca=IDMarca_PROD))
AND 
((@Descuento is null) or (@Descuento >= Descuento_PROD))
GO

--USUARIOS

CREATE PROCEDURE spAgregarUsuario
(
	@IdUsuario char(12),
	@NombreUsuario char(30),
	@ApellidoUsuario char(40),
	@Password char(15),
	@DniUsuario char(9),
	@EmailUsuario char(40),
	@NroTelefono char(12),
	@FechaNacUsuario date
)
	AS
	
	INSERT INTO USUARIOS(IDUsuario, Admin_USU, Apellido_USU, Nombre_USU, DNI_USU, Email_USU, nroCel_USU, Password_USU, FechaNac_USU)
	SELECT @IdUsuario, 0, @ApellidoUsuario, @NombreUsuario, @DniUsuario, @EmailUsuario, @NroTelefono, @Password, @FechaNacUsuario
GO

--MENU USUARIO

	--COMPRAS

CREATE PROCEDURE spObtenerComprasUsuario
(
	@IdUsuario char(20)
)
AS
SELECT IDVenta as 'ID Venta', NroTarjeta_VENTA as 'Nro Tarjeta', IDUsuario_VENTA as 'Codigo de Usuario', Direccion_DIR as 'Direccion', Descuento_VENTA as 'Descuento',
Total_VENTA as 'Total', Costo_ENVIO as 'Precio Envio',Fecha_VENTA as 'Fecha', Estado   FROM VENTAS inner join DirecxUsuario on IDUsuario_VENTA = IDUsuario_DIR
and CodDirreccion_VENTA = CodDirreccion inner join ENVIOS on IDEnvio = IDEnvio_VENTA  WHERE IDUsuario_VENTA = @IdUsuario
GO


	--Tarjetas_x_Usuario
CREATE PROCEDURE spObtenerTarjetasUsuario
(
	@IdUsuario char(20)
)
AS
SELECT  IDUsuario_TxU ,NroTarjeta as 'Nro Tarjeta',IDTarjeta_TxU as 'Codigo', Titular,Vencimiento,TARJETAS.Nombre_TARJ as Tarjeta FROM TarjetasxUsuario inner join TARJETAS on TARJETAS.IDTarjeta_TARJ = TarjetasxUsuario.IDTarjeta_TxU WHERE IDUsuario_TxU = @IdUsuario AND Activo_TxU = 1
GO

	--Direcciones_x_Usuario
CREATE PROCEDURE spObtenerDireccionesUsuario
(
	@IdUsuario char(20)
)
AS
SELECT IDUsuario_DIR, CodDirreccion as 'Identificador', Provincia_DIR as 'Provincia', Direccion_DIR as 'Direccion' FROM DirecxUsuario WHERE IDUsuario_DIR = @IdUsuario AND Activo_Dir = 1
GO


--CANCELAR COMPRA
CREATE PROCEDURE spCancelarCompra
(
	@IdVenta int
)
AS
UPDATE VENTAS
SET Estado = 1 WHERE IDVenta = @IdVenta
GO


--Eliminar MedioDePago
create procedure spEliminarMdP
(
	@IdUsuario char(12),
	@IdTarjxU char(4),
	@NroTarjeta char(16)
)
as
begin
UPDATE TarjetasxUsuario
SET Activo_TxU = 0 WHERE IDUsuario_TxU = @IdUsuario AND IDTarjeta_TxU = @IdTarjxU AND NroTarjeta = @NroTarjeta
end
GO

--Eliminar Direccion
create procedure spEliminarDireccion
(
	@IdUsuario char(12),
	@CodDireccion int
)
as
begin
UPDATE DirecxUsuario SET Activo_DIR = 0 WHERE IDUsuario_DIR = @IdUsuario AND CodDirreccion = @CodDireccion
end
Go


--Agregad MedioDePago
create procedure spAgregarMdP
(
	@IdUsuario char(12),
	@NroTarjeta char(16),
	@IdTarj char(4),
	@Titular char(30),
	@Venc date
)
as
Insert into TarjetasxUsuario(IDUsuario_TxU,NroTarjeta,IDTarjeta_TxU,Titular,Vencimiento, Activo_TxU)
select @IdUsuario,@NroTarjeta, @IdTarj, @Titular, @Venc, 1
GO

--Agregar Direccion
create procedure spAgregarDireccion
(
	@IdUsuario char(12),
	@Provincia char(40),
	@Direccion char(40)
)
as
Insert into DirecxUsuario(IDUsuario_DIR,Provincia_DIR,Direccion_DIR, Activo_DIR)
select @IdUsuario, @Provincia, @Direccion, 1
GO

CREATE PROCEDURE spAgregarVenta
(
	@NroTarjeta char(16), 
	@IDUsuario char(12),
	@CodDireccion smallint,
	@Descuento float,
	@Total money,
	@IDEnvio char(2),
	@Estado tinyint 
)

AS 
INSERT INTO VENTAS (NroTarjeta_VENTA,IDUsuario_VENTA,CodDirreccion_VENTA,
		Descuento_VENTA,Total_VENTA,IDEnvio_VENTA,Estado,Fecha_VENTA)
SELECT @NroTarjeta,@IDusuario,@CodDireccion,@Descuento,@Total,@IDEnvio,@Estado,getdate()

GO



CREATE PROCEDURE spAgregarDetVenta
(
	@IDVenta char(4),
	@IDProducto char(4),
	@Descuento float,
	@Cantidad int,
	@PrecioUni money
)
AS 
INSERT INTO DETVENTAS (IDVenta_DETV,IDProducto_DETV,Descuento_DETV,Cantidad_DETV,PrecioUnitario_DETV)
SELECT @IDVenta,@IDProducto,@Descuento,@Cantidad,@PrecioUni

GO

CREATE PROCEDURE spAgregarProducto
(
	@IDProducto char(4),
	@Nombre_PROD char(30),
	@IdCategoria_PROD char(4),
	@IdSubCategoria_PROD char(4),
	@IDMarca_PROD char(4),
	@Descripcion_PROD char(1000),
	@Stock_PROD int,
	@Precio_PROD money,
	@Descuento_PROD float,
	@Activo bit
)
	AS
	
	INSERT INTO PRODUCTOS(IDProducto, Nombre_PROD, IDCategoria_PROD,IDSubCategoria_PROD, IDMarca_PROD, Descripcion_PROD, Stock_PROD
	, Precio_PROD, Descuento_PROD, RutaImagen, ACTIVO)
	SELECT @IDProducto, @Nombre_PROD, @IdCategoria_PROD, @IdSubCategoria_PROD, @IDMarca_PROD, @Descripcion_PROD,
	 @Stock_PROD, @Precio_PROD,@Descuento_PROD,'~/Assets/Images/PDef.png',1
GO

create procedure spProcesarCompra
(
	@IdVenta int
)
AS
UPDATE VENTAS
SET Estado = 2 WHERE IDVenta = @IdVenta
GO

CREATE PROCEDURE spAgregarMarca
(
	@IDMarca char(4),
	@Nombre_MARCA char(20)
	
)
	AS
	
	INSERT INTO MARCAS(IDMarca, Nombre_MARCA)
	SELECT @IDMarca, @Nombre_MARCA
GO

CREATE procedure ActualizarProd(
@IDProducto char(4),
@Nombre_PROD char(30),
@IDMarca_PROD char(4),
@IDCategoria_PROD char(4),
@IDSubCategoria_PROD char (4),
@Descripcion_PROD char(1000),
@Stock_PROD int,
@Precio_PROD money,
@Descuento_PROD float,
@ACTIVO bit
)
as
update PRODUCTOS 
set Nombre_PROD=@Nombre_PROD, 
Descripcion_PROD=@Descripcion_PROD,
Stock_PROD=@Stock_PROD,
Precio_PROD=@Precio_PROD,
IDMarca_PROD=@IDMarca_PROD,
IDCategoria_PROD = @IDCategoria_PROD,
IDSubCategoria_PROD = @IDSubCategoria_PROD,
Descuento_PROD=@Descuento_PROD,
ACTIVO=@ACTIVO
where IDProducto=@IDProducto
GO

--------------TRIGGERS-----------------

CREATE TRIGGER DevolverStock
on Ventas
after update
as BEGIN
set nocount on;

if(1 = (select estado from inserted))
BEGIN
Declare @Cantidad int
Declare @IdProd char(4)
Declare FilaDet CURSOR FOR select Cantidad_DETV, IDProducto_DETV from DETVENTAS where IDVenta_DETV = (select IDVenta from inserted)
Open FilaDet
FETCH NEXT FROM FilaDet into @Cantidad, @IdProd
WHILE @@FETCH_STATUS = 0

BEGIN
update PRODUCTOS
set Stock_PROD = Stock_PROD + @Cantidad
where IDProducto = @IdProd
FETCH NEXT FROM FilaDet into @Cantidad, @IdProd
END
CLOSE FilaDet
Deallocate FilaDet
END

END
GO

CREATE TRIGGER bajaStock ON DETVENTAS
AFTER INSERT
AS
BEGIN 
SET NOCOUNT ON
UPDATE PRODUCTOS SET Stock_PROD = Stock_PROD - 
(SELECT Cantidad_DETV FROM INSERTED) WHERE IDProducto = (SELECT IDProducto_DETV FROM INSERTED)
END
GO

CREATE TRIGGER controlarProductos 
ON PRODUCTOS AFTER UPDATE
AS
BEGIN
set nocount on;
	IF UPDATE (Stock_PROD)
	BEGIN
		IF((SELECT Stock_PROD FROM INSERTED) = 0)
		BEGIN
			UPDATE PRODUCTOS SET ACTIVO = 0 WHERE (IDProducto = (SELECT IDProducto FROM INSERTED))
		END
		ELSE
		BEGIN
			UPDATE PRODUCTOS SET ACTIVO = 1 WHERE (IDProducto = (SELECT IDProducto FROM INSERTED))
		END
	END
END
GO

