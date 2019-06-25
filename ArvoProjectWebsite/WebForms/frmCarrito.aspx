<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCarrito.aspx.cs" Inherits="ArvoProjectWebsite.frmCarrito" %>

<!DOCTYPE html>

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Compraso</title>

    <link href="/Assets/Styles/Main.css" rel="stylesheet" />
    <link href="/Assets/Styles/productos.css" rel="stylesheet" />
    <link href="/Assets/Styles/master.css" rel="stylesheet" />
    <link href="/Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" />

        <link href="/Assets/Styles/Main.css" rel="stylesheet" />
        <link href="/Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" />

</head>
<html>
<body>
    <!--ENCABEZADO-->
    <form id="form2" runat="server">

        <div class="container-fluid mt-2 mb-2">
            <div class="row align-items-center align-content-between">
                <div class="col-3">
                    <a href="/default.aspx" id="logo">
                        <img src="/Assets/Images/compraso_l2.png" alt="Compraso" /></a>
                </div>
                <div class="col-5" style="margin-top: 15px">
                    <div class="input-group mb-3">

                        <asp:TextBox class="form-control py-2 border-right-0 border" type="text" placeholder="Buscar producto..." ID="txtBuscador" runat="server"></asp:TextBox>

                        <span class="input-group-append">
                            <%-- <asp:Button ID="Button1" runat="server" Text="Button" />--%>
                            <button class="btn btn-outline-secondary border-left-0 border" type="button" runat="server" onserverclick="ejecutarBuscador">
                                <i class="fa fa-search"></i>
                            </button>
                        </span>
                    </div>
                </div>

                <div class="col-3 text-right">
                    <asp:LinkButton class="text-dark" ID="InicSec" runat="server" Visible="False" CommandName="init" OnCommand="btnUser_Command"><i class="far fa-user fa-lg"></i> Iniciar sesión</asp:LinkButton>
                    <asp:LinkButton class="text-dark" ID="Cuenta" runat="server" Visible="False" CommandName="acc" OnCommand="btnUser_Command" ToolTip="Mi perfil"><i class="far fa-user-circle fa-lg"></i> </asp:LinkButton>
                    <asp:LinkButton class="text-dark" ID="CerrSec" runat="server" CommandName="close" OnCommand="btnUser_Command" Visible="False"><i class="fas fa-times-circle"></i> Cerrar sesión </asp:LinkButton>
                </div>
                <div class="col-1">
                    <asp:LinkButton class="text-dark" ID="Carrito" runat="server" OnClick="Carrito_Click"><i class="fas fa-shopping-cart fa-lg"></i></asp:LinkButton>

                </div>


            </div>
        </div>

        <!--BARRA MENU-->
        <nav class="flex">

            <asp:LinkButton ID="item0" CssClass="navbar-item" runat="server" CommandArgument="C001" CommandName="IDCat" OnCommand="item_Command">Informática</asp:LinkButton>
            <asp:LinkButton ID="item1" CssClass="navbar-item" runat="server" CommandArgument="C002" CommandName="IDCat" OnCommand="item_Command">TV, Audio y Video</asp:LinkButton>
            <asp:LinkButton ID="item2" CssClass="navbar-item" runat="server" CommandArgument="C003" CommandName="IDCat" OnCommand="item_Command">Electrodomésticos</asp:LinkButton>
            <asp:LinkButton ID="item3" CssClass="navbar-item" runat="server" CommandArgument="C004" CommandName="IDCat" OnCommand="item_Command">Celulares y Tablets</asp:LinkButton>
            <asp:LinkButton ID="item4" CssClass="navbar-item" runat="server" CommandArgument="C005" CommandName="IDCat" OnCommand="item_Command">Casa y Jardín</asp:LinkButton>

        </nav>
        <div>

            <br />
&nbsp;<asp:GridView ID="grdCarrito" runat="server" OnRowCommand="grdCarrito_RowCommand"  OnRowDeleting="grdCarrito_RowDeleting" AllowSorting="True" OnRowDataBound="grdCarrito_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" OnSorting="grdCarrito_Sorting" CssClass="text-center" OnRowCancelingEdit="grdCarrito_RowCancelingEdit" OnRowEditing="grdCarrito_RowEditing" OnRowUpdating="grdCarrito_RowUpdating" OnRowCreated="grdCarrito_RowCreated">
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

                        &nbsp;<asp:TextBox ID="txtCantidad" runat="server" Height="16px" Style="margin-top: 0px" Width="50px"></asp:TextBox>

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
            <asp:Label ID="lblNocarrito" runat="server" Text="No posee ningún articulo en el carrito."></asp:Label>
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
