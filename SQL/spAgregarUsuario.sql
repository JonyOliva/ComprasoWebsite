use BD_COMPRASO
go
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