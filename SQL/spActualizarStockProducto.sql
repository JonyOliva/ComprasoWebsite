CREATE PROCEDURE spActualizarStockProducto
(
@IDProducto char(10),
@Stock float,
@Cantidad int
)
AS
UPDATE PRODUCTOS SET Stock=Stock+Cantidad WHERE IDProducto=@IDProducto
RETURN