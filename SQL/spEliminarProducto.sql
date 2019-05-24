CREATE PROCEDURE spEliminarProducto
(
@IDProducto char(10),
@Nombre char(10),
@Cat char(10),
@SubCat char(10),
@Marca char(10),
@Descrip text,
@FichaTec char(50),
@Stock float,
@Precio float,
@Descuento float
)
AS
IF((SELECT Stock FROM PRODUCTOS WHERE IDProducto=@IDProducto) <= 1)
DELETE FROM PRODUCTOS WHERE IDProducto=@IDProducto
ELSE
UPDATE PRODUCTOS SET Stock=Stock-1 WHERE IDProducto=@IDProducto
RETURN