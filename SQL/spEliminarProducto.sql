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
DELETE FROM PRODUCTOS WHERE IDProducto=@IDProducto
RETURN