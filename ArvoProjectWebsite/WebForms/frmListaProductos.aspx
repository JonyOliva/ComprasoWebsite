<%@ Page Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmListaProductos.aspx.cs" Inherits="ArvoProjectWebsite.frmListaProductos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Assets/Styles/Compras.css" rel="stylesheet" />
    <!--
        ESTE FORM ES PARA FINALIZAR LA COMPRA DE TODOS LOS PRODUCTOS, OSEA EL FORM SIGUIENTE AL DEL CARRITO
-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  

        <div style="background-color: whitesmoke;">
            <br />
            <div class="container border rounded bg-white">
                <div class="row justify-content-end">
                    <h6 class="col offset-8">Ordenar por:</h6>
                    <div class="col">
                        <asp:DropDownList ID="ddlOrdenar" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrdenar_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="Precio_PROD ASC">Menor precio</asp:ListItem>
                            <asp:ListItem Value="Precio_PROD DESC">Mayor precio</asp:ListItem>
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
                        <asp:ListView ID="lstViewProductos" runat="server" GroupItemCount="4" OnDataBound="lstViewProductos_DataBound">
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

            <br />
        </div>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</asp:content>
