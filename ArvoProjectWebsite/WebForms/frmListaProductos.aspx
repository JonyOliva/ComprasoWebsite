<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListaProductos.aspx.cs" Inherits="ArvoProjectWebsite.frmListaProductos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
     
    <title>Productos</title>
    <link href="/Assets/Styles/listaProductos.css" rel="stylesheet" />
    <link href="/Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />

</head>


<body>
    
    <form id="form1" runat="server">

         <!--ENCABEZADO          
         
             ESTE FORM SE CONECTA CON LA BD DEL SERVIDOR
         -->
        <div>
            
            <div class="container">
                <div class="row"> 
                    
                    <div class="col text-right">
                        <asp:DropDownList ID="ddlOrdenar" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1">Menor a mayo</asp:ListItem>
                        <asp:ListItem Value="2">Mayor a menor</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    
                </div>
                <div class="row text-center">
                    <div class="col-md-3">
                        <h5>Marcas</h5>
                        <asp:RadioButtonList ID="rblMarcas" runat="server" Font-Overline="False" TextAlign="Left">
                        </asp:RadioButtonList>
                        <h5>Categorias</h5>
                        <asp:RadioButtonList ID="rblCat" runat="server" Font-Overline="False" TextAlign="Left">
                        </asp:RadioButtonList>
                        <h5>Subcategorias</h5>
                        <asp:RadioButtonList ID="rblSubCat" runat="server" Font-Overline="False" TextAlign="Left">
                        </asp:RadioButtonList>

                    </div>
                    <div class="col-md-9">
                        <asp:ListView ID="lstViewProductos" runat="server" DataSourceID="sqldataProductos" GroupItemCount="5">
                <EditItemTemplate>
                    <td runat="server" style="background-color: #999999;">Nombre_PROD:
                        <asp:TextBox ID="Nombre_PRODTextBox" runat="server" Text='<%# Bind("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:TextBox ID="Stock_PRODTextBox" runat="server" Text='<%# Bind("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:TextBox ID="Precio_PRODTextBox" runat="server" Text='<%# Bind("Precio_PROD") %>' />
                        <br />
                        RutaImagen:
                        <asp:TextBox ID="RutaImagenTextBox" runat="server" Text='<%# Bind("RutaImagen") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No se han devuelto datos.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
<td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">Nombre_PROD:
                        <asp:TextBox ID="Nombre_PRODTextBox" runat="server" Text='<%# Bind("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:TextBox ID="Stock_PRODTextBox" runat="server" Text='<%# Bind("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:TextBox ID="Precio_PRODTextBox" runat="server" Text='<%# Bind("Precio_PROD") %>' />
                        <br />
                        RutaImagen:
                        <asp:TextBox ID="RutaImagenTextBox" runat="server" Text='<%# Bind("RutaImagen") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #E0FFFF;color: #333333;">Nombre_PROD:
                        <asp:Label ID="Nombre_PRODLabel" runat="server" Text='<%# Eval("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:Label ID="Stock_PRODLabel" runat="server" Text='<%# Eval("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:Label ID="Precio_PRODLabel" runat="server" Text='<%# Eval("Precio_PROD") %>' />
                        <br />
                        <br />
                        <asp:ImageButton ID="imgProducto" runat="server" ImageUrl='<%# Eval("RutaImagen").ToString().Trim() %>' 
                            style="max-height:480px;max-width:320px;height:auto;width:auto;"/>
                        <br /></td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">Nombre_PROD:
                        <asp:Label ID="Nombre_PRODLabel" runat="server" Text='<%# Eval("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:Label ID="Stock_PRODLabel" runat="server" Text='<%# Eval("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:Label ID="Precio_PRODLabel" runat="server" Text='<%# Eval("Precio_PROD") %>' />
                        <br />RutaImagen:
                        <asp:Label ID="RutaImagenLabel" runat="server" Text='<%# Eval("RutaImagen") %>' />
                        <br />
                    </td>
                </SelectedItemTemplate>
            </asp:ListView>
                    </div>
                </div>

            </div>

            <asp:SqlDataSource ID="sqldataProductos" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionStringLocal %>" SelectCommand="SELECT [Nombre_PROD], [Stock_PROD], [Precio_PROD], [RutaImagen] FROM [PRODUCTOS] WHERE ([ACTIVO] = @ACTIVO)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="true" Name="ACTIVO" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        
    </form>

        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" ></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" ></script>
</body>
</html>