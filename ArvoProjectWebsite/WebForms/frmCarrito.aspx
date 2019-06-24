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
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.cs "/>
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
        <div>
            <br />
&nbsp;<asp:GridView ID="grdCarrito" runat="server" OnRowCommand="grdCarrito_RowCommand"  OnRowDeleting="grdCarrito_RowDeleting" AllowSorting="True" OnRowDataBound="grdCarrito_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" OnSorting="grdCarrito_Sorting" CssClass="text-center" OnRowCancelingEdit="grdCarrito_RowCancelingEdit" OnRowEditing="grdCarrito_RowEditing" OnRowUpdating="grdCarrito_RowUpdating">
            <Columns>
                <asp:ImageField DataImageUrlField="RutaImagen">
                    <ControlStyle Height="100px" Width="150px" />
                </asp:ImageField>
                <asp:CommandField DeleteText="Quitar" ShowDeleteButton="True" />
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Width="66px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtCantidad" runat="server" Width="63px"  Columns="5" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#0033CC" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
            <asp:Label ID="lblNocarrito" runat="server" Text="No posee ningún articulo en el carrito." ></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
      
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkSeguircom" runat="server" OnClick="lnkSeguircom_Click" CssClass="align-self-center" Font-Underline="True" ForeColor="#3333CC">Seguir comprando</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkComprar" runat="server" OnClick="lnkComprar_Click" CssClass="align-self-auto" Font-Underline="True" ForeColor="#3333CC">Realizar compra</asp:LinkButton>
    </form>
</body>
</html>
