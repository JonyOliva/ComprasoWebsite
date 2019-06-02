<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ArvoProjectWebsite.Index" %>

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
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css"/>

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

                <div class="col-2 text-right">
                         <asp:LinkButton class="text-dark" ID="InicSec" runat="server" OnClick="InicSec_Click"><i class="far fa-user fa-lg"></i> Iniciar sesión</asp:LinkButton>
                </div>
                <div class="col-1"> 
                     <asp:LinkButton class="text-dark" ID="Carrito" runat="server" OnClick="Carrito_Click"><i class="fas fa-shopping-cart fa-lg"></i></asp:LinkButton>
               
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
        <a class="navbar-item" href="/WebForms/frmListaProductos.aspx">Tecnología</a>
        <a class="navbar-item" href="#">Electrodomésticos</a>
        <a class="navbar-item" href="#">Categoria</a>
        <a class="navbar-item" href="#">Categoria</a>
        <a class="navbar-item" href="#">Casa y Jardín</a>
       
    </nav>

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
    

    
    <!--FOOTER (En construccion)-->
        <footer>
            <!--ARVO SRL | Todos los derechos reservados-->
        </footer>
        

        
    </form>

        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
</body>
</html>
