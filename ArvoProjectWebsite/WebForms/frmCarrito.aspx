<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCarrito.aspx.cs" Inherits="ArvoProjectWebsite.frmCarrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="lblNocarrito" runat="server" Text="No posee  ningún articulo en el carrito."></asp:Label>
        <asp:GridView ID="grdCarrito" runat="server" OnRowCommand="grdCarrito_RowCommand" OnRowDeleting="grdCarrito_RowDeleting">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Quitar" />
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="lnkSeguircom" runat="server" OnClick="lnkSeguircom_Click">Seguir comprando</asp:LinkButton>
        <asp:LinkButton ID="lnkComprar" runat="server" OnClick="lnkComprar_Click">Proceder a la comprar</asp:LinkButton>
    </form>
</body>
</html>
