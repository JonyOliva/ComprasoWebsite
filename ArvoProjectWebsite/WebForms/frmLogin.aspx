<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ArvoProjectWebsite.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
    <title>Iniciar Sesión</title>

    <link href="/Assets/Styles/usuario.css" rel="stylesheet" />
    <link href="/Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />
  

</head>
<body class="fondogris">
    <form id="form1" runat="server">
        
        <div class="caja">
        <div class="container" >
           
            <div class="row">
                <img src="../Assets/Images/compraso_l.png" alt="logo" /></div>
           
            <div class="row text-center">  <div class="col bg-azul"><h4 class="text-light">Iniciar Sesión</h4></div>
                </div>
             <div class="row">
                <hr />
            </div>
             <div class="row"> <div class="col-5 text-right">Usuario:</div>
                 <div class="col text-left"><asp:TextBox ID="txtUsuario" runat="server" Width="220px">
                                            </asp:TextBox>
                     <asp:Label ID="lblAst1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                 </div>
             </div>
            <div class="row pt-2"> <div class="col-5 text-right">Contraseña:</div>
                 <div class="col text-left"><asp:TextBox ID="txtPass" runat="server" Width="220px"></asp:TextBox>
                     <asp:Label ID="lblAst2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                </div>
             </div>
              <div class="row pt-2"> <div class="col-9 text-right"><asp:CheckBox ID="chrRecordar" runat="server" Text="&nbsp Recordar Usuario " /></div>
        </div>
            <div class="row">
                <div class="text-center"> <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label></div>
                <br />
            </div>
            <div class="row pt-2 align-items-lg-center text-center ">
                <div class="col align-self-md-center"> <asp:Button ID="btnLogin" CssClass="btnlogin bg-azul" runat="server" Text="Ingresar" /></div></div>
            <br />
            
            <div class="row">
                <div class="col text-left">
                <asp:LinkButton ID="linkOlvido" runat="server">¿Olvidó su contraseña?</asp:LinkButton></div>
                <div class="col text-right">
                ¿No está registrado? &nbsp<asp:LinkButton ID="linkRegistrar" runat="server">Registrarse</asp:LinkButton></div></div>
            <div class="row">
                <hr />
            </div>
        </div>
       
      </div>       
    
    </form>
    <p>
&nbsp;
    </p>
</body>
</html>
