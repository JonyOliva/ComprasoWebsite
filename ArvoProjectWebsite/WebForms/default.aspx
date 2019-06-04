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
      <img class="d-block w-100" src="/Assets/Images/promo1.png" alt="Promo 1"/>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="/Assets/Images/promo2.png" alt="Promo 2"/>
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="/Assets/Images/promo2.png" alt="Promo 3"/>
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

        
        <section class="containerproductos flex text-center" id="Destacados">
                        <div class="displayProducto">
                <img class="fotoproducto" src="/Assets/Images/tv.jpg" alt="Producto" />
                <p class="nombreproducto">Nombre producto</p>
                <p class="precio">$13.000</p>
                <hr />
               <%-- <asp:LinkButton ID="LinkButton1" CssClass="btnComprar" runat="server">Añadir al carrito</asp:LinkButton>--%>
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
          

        </section>
</asp:Content>

