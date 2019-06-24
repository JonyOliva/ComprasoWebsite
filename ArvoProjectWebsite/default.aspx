<%@ Page Title="Compraso" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ArvoProjectWebsite.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--CARROUSEL--%>
<div id="carouselOfertas" class="carousel slide" data-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src="/Assets/Images/promo1_.png" alt="Promo 1"/>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="/Assets/Images/promo2.png" alt="Promo 2"/>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="/Assets/Images/promo3.jpg" alt="Promo 3"/>
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselOfertas" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselOfertas" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>



    <!--SECCION PRODUCTOS DESTACADOS -->
    <div class="container">

        <div class="text-primary" style="font-size: xx-large; font-weight: bold;">Destacados</div>

        <asp:ListView ID="lstProductosDest" runat="server" DataKeyNames="IDProducto" DataSourceID="SqlDataSource1">
            <EmptyDataTemplate>
                <table style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No se han devuelto datos.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td runat="server" class="rounded border-primary" style="text-align: center !important">
                        <table class="altaclase">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgProducto" runat="server" CommandArgument='<%# Eval("IDProducto") %>' CommandName="IdProd" OnCommand="imgProducto_Command" ImageUrl='<%# Eval("RutaImagen").ToString().Trim() %>' style="max-height:144px;max-width:200px;height:auto;width:auto;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Nombre_PRODLabel" runat="server" CssClass="font-weight-bold" Text='<%# Eval("Nombre_PROD") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDescuento" runat="server" CssClass=" text-success border border-success " Text='<%# Eval("Descuento_PROD") + "% OFF" %>' Visible='<%# Convert.ToSingle(Eval("Descuento_PROD"))>0 %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPrecioAnt" runat="server" Text='<%# "$" + Entidad.Utilidades.precioaMostar(Eval("Precio_PROD")) %>' Visible='<%# Convert.ToSingle(Eval("Descuento_PROD"))>0 %>' style="text-decoration:line-through; font-size: small; color: gray"></asp:Label>
                                    <asp:Label ID="Precio_PRODLabel" runat="server" CssClass="text-danger" Text='<%# "$" + Entidad.Utilidades.precioaMostar(Entidad.Utilidades.getPrecioConDescuento(Eval("Precio_PROD"), Eval("Descuento_PROD"))) %>' style="font-size: larger;"></asp:Label>                                    
                                </td>
                            </tr>
                        </table>
                        <asp:ImageButton ID="btnComprar" runat="server" ImageUrl="~/Assets/Images/btnComprar.png" Width="40%" ImageAlign="Middle"  />
                    </td>

                <%--<td runat="server" style="background-color: #E0FFFF;color: #333333;">IDProducto:
                    <asp:Label ID="IDProductoLabel" runat="server" Text='<%# Eval("IDProducto") %>' />
                    <br />
                    Nombre_PROD:
                    <asp:Label ID="Nombre_PRODLabel" runat="server" Text='<%# Eval("Nombre_PROD") %>' />
                    <br />
                    Precio_PROD:
                    <asp:Label ID="Precio_PRODLabel" runat="server" Text='<%# Eval("Precio_PROD") %>' />
                    <br />
                    RutaImagen:
                    <asp:Label ID="RutaImagenLabel" runat="server" Text='<%# Eval("RutaImagen") %>' />
                    <br />
                    Descuento_PROD:
                    <asp:Label ID="Descuento_PRODLabel" runat="server" Text='<%# Eval("Descuento_PROD") %>' />
                    <br />
                </td>--%>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </table>
                <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionStringLocal %>" SelectCommand="SELECT [IDProducto], [Nombre_PROD], [Precio_PROD], [RutaImagen], [Descuento_PROD] FROM [PRODUCTOS] WHERE (([ACTIVO] = @ACTIVO) AND ([Descuento_PROD] &gt; @Descuento_PROD)) ORDER BY [Descuento_PROD] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="true" Name="ACTIVO" Type="Boolean" />
                <asp:Parameter DefaultValue="0" Name="Descuento_PROD" Type="Double" />
            </SelectParameters>
        </asp:SqlDataSource>



    </div>
        
        <%--<section class="containerproductos flex text-center" id="Destacados">
                        <div class="displayProducto">
                <img class="fotoproducto" src="/Assets/Images/tv.jpg" alt="Producto" />
                <p class="nombreproducto">Nombre producto</p>
                <p class="precio">$13.000</p>
                <hr />
               <%-- <asp:LinkButton ID="LinkButton1" CssClass="btnComprar" runat="server">Añadir al carrito</asp:LinkButton>
                 <a class="btnComprar" href="#">Añadir al carrito</a>

            </div>

            <div class="displayProducto">
                <img class="fotoproducto" src="/Assets/Images/notebook.jpg" alt="Producto" />
                <p class="nombreproducto">Nombre producto</p>
                <p class="precio">Precio</p>
                <hr />
                <a class="btnComprar" href="#">Añadir al carrito</a>

            </div>

            <div class="displayProducto">
                <img class="fotoproducto" src="#" alt="Producto" />
                <p class="nombreproducto">Nombre producto</p>
                <p class="precio">Precio</p>
                <hr />
                <a class="btnComprar" href="#">Añadir al carrito</a>

            </div>

            <div class="displayProducto">
                <img class="fotoproducto" src="#" alt="Producto" />
                <p class="nombreproducto">Nombre producto</p>
                <p class="precio">Precio</p>
                <hr />
                <a class="btnComprar" href="#">Añadir al carrito</a>

            </div>
          

        </section>--%>
</asp:Content>

