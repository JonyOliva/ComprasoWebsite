<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ArvoProjectWebsite.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
    <title>Iniciar Sesión</title>

    <link href="Assets/Styles/usuario.css" rel="stylesheet" />
    <link href="Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />
  

</head>
<body>
    <form id="form1" runat="server">
        
        <div class="container-fluid align-content-xl-stretch">
            <div class="row">  <div class="col"><h1 class="azul">Iniciar Sesión</h1></div>
                </div>
             <div class="row"> <div class="col">Usuario:</div>
                 <div class="col"><asp:TextBox ID="txtUsuario" runat="server" Width="220px"></asp:TextBox></div>
             </div>
            <div class="row pt-2"> <div class="col">Contraseña:</div>
                 <div class="col"><asp:TextBox ID="txtPass" runat="server" Width="220px"></asp:TextBox></div>
             </div>
              <div class="row pt-2"> <div class="col"><asp:CheckBox ID="chrRecordar" runat="server" Text="Recordar Usuario " TextAlign="Left" /></div>
        </div>
        
       
      
        
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Entrar" />
        <br />
        <br />
        <asp:LinkButton ID="linkOlvido" runat="server">¿Olvidó su contraseña?</asp:LinkButton>
    </form>
</body>
</html>
