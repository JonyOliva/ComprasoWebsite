<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListaProductos.aspx.cs" Inherits="ArvoProjectWebsite.frmListaProductos" %>

<!DOCTYPE html>

<html>
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

<body>
    <!--ENCABEZADO-->
    <form id="form2" runat="server">

        <div class="container-fluid mt-2 mb-2">
            <div class="row align-items-center align-content-between">
                <div class="col-3"><a href="/default.aspx" id="logo">
                    <img src="/Assets/Images/compraso_l2.png" alt="Compraso" /></a></div>
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

        <div style="background-color: whitesmoke;">
            <br />
            <div class="container border rounded bg-white">
                <div class="row justify-content-end">
                    <h6 class="col offset-8">Ordenar por:</h6>
                    <div class="col">
                        <asp:DropDownList ID="ddlOrdenar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrdenar_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">Menor precio</asp:ListItem>
                            <asp:ListItem Value="2">Mayor precio</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="row">
                            <h6 class="col">Categorias</h6>
                            <asp:DropDownList ID="ddlCat" runat="server" CssClass="col" AutoPostBack="True" OnSelectedIndexChanged="ddlCat_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div class="row">
                            <h6 class="col">Subcategorias</h6>
                            <asp:DropDownList ID="ddlSubCat" runat="server" CssClass="col" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCat_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div class="row">
                            <h6 class="col">Marcas</h6>
                            <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="col" AutoPostBack="True" OnSelectedIndexChanged="ddlMarcas_SelectedIndexChanged">
                            </asp:DropDownList>

                        </div>
                        <br />
                        <br />
                        <div class="row justify-content-center">
                            <asp:Label ID="lblCant" runat="server"></asp:Label>
                        </div>
                        <br />
                    </div>

                    <div class="col-md-9">
                        <asp:ListView ID="lstViewProductos" runat="server" DataSourceID="sqldataProductos" GroupItemCount="4" OnDataBound="lstViewProductos_DataBound">
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                    <tr>
                                        <td>No se han devuelto datos.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>
                            <ItemTemplate>
                                <td runat="server" class="rounded border-primary" style="text-align: center !important">
                                    <table class="altaclase">
                                        <tr>
                                            <td class="auto-style2">
                                                <asp:ImageButton ID="imgProducto" runat="server" CommandArgument='<%# Eval("IDProducto") %>' CommandName="IdProd" ImageUrl='<%# Eval("RutaImagen").ToString().Trim() %>' OnCommand="imgProducto_Command" Style="max-height: 144px; max-width: 200px; height: auto; width: auto;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <asp:Label ID="Nombre_PRODLabel" runat="server" CssClass="font-weight-bold" Text='<%# Eval("Nombre_PROD") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <asp:Label ID="lblDescuento" runat="server" CssClass=" text-success border border-success " Text='<%# Eval("Descuento_PROD") + "% OFF" %>' Visible='<%# Convert.ToSingle(Eval("Descuento_PROD"))>0 %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <asp:Label ID="lblPrecioAnt" runat="server" Text='<%# "$" + Entidad.Utilidades.precioaMostar(Eval("Precio_PROD")) %>' Visible='<%# Convert.ToSingle(Eval("Descuento_PROD"))>0 %>' Style="text-decoration: line-through; font-size: small; color: gray"></asp:Label>
                                                <asp:Label ID="Precio_PRODLabel" runat="server" CssClass="text-danger" Text='<%# "$" + Entidad.Utilidades.precioaMostar(Entidad.Utilidades.getPrecioConDescuento(Eval("Precio_PROD"), Eval("Descuento_PROD"))) %>' Style="font-size: larger;"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:ImageButton ID="btnComprar" runat="server" ImageUrl="~/Assets/Images/btnComprar.png" Width="40%" CommandArgument='<%# Eval("IDProducto") %>' CommandName="IDProd" ImageAlign="Middle" OnCommand="lbtnAñadircarr_Command" />
                                </td>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:ListView>
                        <br />
                    </div>
                </div>

            </div>

            <asp:SqlDataSource ID="sqldataProductos" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionStringLocal %>" SelectCommand="SELECT [IDProducto], [Nombre_PROD], [RutaImagen], [Descuento_PROD], [Precio_PROD] FROM [PRODUCTOS] WHERE (([ACTIVO] = @ACTIVO) AND ([IDCategoria_PROD] = @IDCategoria_PROD))" CancelSelectOnNullParameter="False">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="ACTIVO" Type="Boolean" />
                    <asp:SessionParameter Name="IDCategoria_PROD" SessionField="filtroCategoria" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </div>

        <footer>
            <!--ARVO SRL | Todos los derechos reservados-->
        </footer>

    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</body>
</html>
