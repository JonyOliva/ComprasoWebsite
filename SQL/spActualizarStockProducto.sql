CREATE PROCEDURE spActualizarStockProducto
(
@IDProducto char(10),
@Nombre char(10),
@Stock float
)
AS
IF((SELECT Stock FROM PRODUCTOS WHERE IDProducto=@IDProducto) <= 1)
DELETE FROM PRODUCTOS WHERE IDProducto=@IDProducto
ELSE
UPDATE PRODUCTOS SET Stock=Stock-1 WHERE IDProducto=@IDProducto
RETURN