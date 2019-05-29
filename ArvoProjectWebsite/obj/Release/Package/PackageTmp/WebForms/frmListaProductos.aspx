<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListaProductos.aspx.cs" Inherits="ArvoProjectWebsite.frmListaProductos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

    <title>Compraso</title>
    <link href="/Assets/Styles/Main.css" rel="stylesheet" />
    <link href="/Assets/Styles/productos.css" rel="stylesheet" />
    <link href="/Assets/Styles/master.css" rel="stylesheet" />
    <link href="/Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>

</head>


<body>
    
    <form id="form1" runat="server">

         <!--ENCABEZADO-->

        <div class="container-fluid">
            <div class="row align-items-center align-content-between">
                <div class="col-3"><a href="index.aspx" id="logo"><img src="/Assets/Images/compraso_l.png" alt="Compraso" /></a></div>
                <div class="col-6" style="margin-top:11px"><div class="input-group mb-3">
            <input class="form-control py-2 border-right-0 border" type="text" placeholder="Buscar producto..." id="buscador" />
            <span class="input-group-append">
                <button class="btn btn-outline-secondary border-left-0 border" type="button">
                    <i class="fa fa-search"></i>
                </button>
              </span></div>  
  </div>

                <div class="col-1"><button class="btn" type="button">
                    <i class="fas fa-shopping-cart"></i>
                </button></div>
                <div class="col-2"> 
                   <asp:LinkButton class="text-decoration-none" ID="InicSec" runat="server"><i class="far fa-user"></i> Iniciar sesión</asp:LinkButton> 
                    </div>


            </div>
        </div>
      
    <%--<header class="header">
        <a href="index.aspx" id="logo"><img src="/Assets/Images/compraso_l.png" alt="Compraso" /></a>
        <input class="searchbar" id="Buscador" placeholder=" Buscar Producto..." />
        <a href="#" class="carrito">carrito</a>
           
    </header>--%>
   

    <!--BARRA MENU-->
        <nav class="flex">
        <a class="navbar-item" href="#">Tecnología</a>
        <a class="navbar-item" href="#">Electrodomésticos</a>
        <a class="navbar-item" href="#">Categoria</a>
        <a class="navbar-item" href="#">Categoria</a>
        <a class="navbar-item" href="#">Casa y Jardín</a>
       
    </nav>
    
        <aside> 


        </aside>
        
        <div>
            <asp:ListView ID="lstViewProductos" runat="server" DataSourceID="sqldataProductos" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="background-color: #FFFFFF;color: #284775;">Nombre_PROD:
                        <asp:Label ID="Nombre_PRODLabel" runat="server" Text='<%# Eval("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:Label ID="Stock_PRODLabel" runat="server" Text='<%# Eval("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:Label ID="Precio_PRODLabel" runat="server" Text='<%# Eval("Precio_PROD") %>' />
                        <br /></td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="background-color: #999999;">Nombre_PROD:
                        <asp:TextBox ID="Nombre_PRODTextBox" runat="server" Text='<%# Bind("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:TextBox ID="Stock_PRODTextBox" runat="server" Text='<%# Bind("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:TextBox ID="Precio_PRODTextBox" runat="server" Text='<%# Bind("Precio_PROD") %>' />
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
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Precio_PROD") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="Button1" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #E0FFFF;color: #333333;">Nombre_PROD:
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Precio_PROD") %>' />
                        <br />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("RutaImagen") %>' />
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
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">Nombre_PROD:
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Nombre_PROD") %>' />
                        <br />Stock_PROD:
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Stock_PROD") %>' />
                        <br />Precio_PROD:
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Precio_PROD") %>' />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="sqldataProductos" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionString %>" SelectCommand="SELECT [Nombre_PROD], [Stock_PROD], [Precio_PROD], [RutaImagen] FROM [PRODUCTOS]"></asp:SqlDataSource>
        </div>
    
    <!--FOOTER (En construccion)-->
        <footer>
            <!--ARVO SRL | Todos los derechos reservados-->
        </footer>
        

        
    </form>

        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
