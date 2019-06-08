<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCarrito.aspx.cs" Inherits="ArvoProjectWebsite.frmCarrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/Assets/Styles/Main.css" rel="stylesheet" />
    <link href="/Assets/Styles/productos.css" rel="stylesheet" />
    <link href="/Assets/Styles/master.css" rel="stylesheet" />
    <link href="/Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.cs
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid mt-2 mb-2">
            <div class="row align-items-center align-content-between">
                <div class="col-3"><a href="/default.aspx" id="logo"><img src="/Assets/Images/compraso_l2.png" alt="Compraso" /></a></div>
                <div class="col-6" style="margin-top:15px"><div class="input-group mb-3">
            &nbsp;</div>  
  </div>

                <div class="col-2 text-right">
                         <asp:LinkButton class="text-dark" ID="InicSec" runat="server" OnClick="InicSec_Click"><i class="far fa-user fa-lg"></i> Iniciar sesión</asp:LinkButton>
                </div>
                <div class="col-1"> 
                     <asp:LinkButton class="text-dark" ID="Carrito" runat="server" OnClick="Carrito_Click"><i class="fas fa-shopping-cart fa-lg"></i></asp:LinkButton>
               
                    </div>


            </div>
        </div>
    
 

    <!--BARRA MENU-->
        <nav class="flex">
        <a class="navbar-item" href="/WebForms/frmListaProductos.aspx">Informática</a>
        <a class="navbar-item" href="#">TV, Audio y Video</a>
        <a class="navbar-item" href="#">Electrodomésticos</a>
        <a class="navbar-item" href="#">Celulares y Tablets</a>
        <a class="navbar-item" href="#">Casa y Jardín</a>
       
    </nav>
        <div style="margin-left: 240px">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="lblNocarrito" runat="server" Text="No posee ningún articulo en el carrito."></asp:Label>
        </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:GridView ID="grdCarrito" runat="server" OnRowCommand="grdCarrito_RowCommand" OnRowDeleting="grdCarrito_RowDeleting" AllowSorting="True" OnRowDataBound="grdCarrito_RowDataBound">
            <Columns>
                <asp:ImageField DataImageUrlField="RutaImagen">
                </asp:ImageField>
                <asp:CommandField DeleteText="Quitar" ShowDeleteButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        &nbsp;<asp:TextBox ID="txtCantidad" runat="server" Height="16px" style="margin-top: 0px" Width="50px">1</asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="lnkSeguircom" runat="server" OnClick="lnkSeguircom_Click">Seguir comprando</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkComprar" runat="server" OnClick="lnkComprar_Click">Proceder a la comprar</asp:LinkButton>
    </form>

    </form>


</body>
</html>
