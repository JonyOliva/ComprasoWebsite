<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProducto.aspx.cs" Inherits="ArvoProjectWebsite.frmProducto" %>


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

         <!--ENCABEZADO          
         
             ESTE FORM SE CONECTA CON LA BD DEL SERVIDOR
         -->

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
    
        <div>


            <div>
                <asp:Label ID="lblContainer" runat="server"></asp:Label>
            </div>

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
