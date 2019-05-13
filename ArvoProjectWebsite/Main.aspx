<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ArvoProjectWebsite.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tienda Online - Compraso </title>
    <link href="Styles/StyleSheetMain.css" rel="stylesheet" />
</head>
<body>
    <form id="formMain" runat="server">
        <h1>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            Alto titulo</h1>
        <nav>
            <h3>Barra loca</h3>
            <ul>
                <li>Categorías</li>
                <li>Iniciar sesión</li>
                <li>Registrarse</li>
            </ul>
        </nav>

        <div class="contenido">

            <aside>
                <h3>al lado</h3>
            </aside>
            <section>
                <h3>sector de contenido&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Hola Jony"></asp:Label>
                </h3>
            </section>
            

        </div>
    </form>
</body>
</html>
