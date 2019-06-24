<%@ Page Title="Continuar Compra" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmCompra.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.frmCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!--
        ESTE FORM ES PARA FINALIZAR LA COMPRA DE TODOS LOS PRODUCTOS, OSEA EL FORM SIGUIENTE AL DEL CARRITO
-->
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMetodo" runat="server" Text="Seleccione metodo de pago"></asp:Label>
    &nbsp;&nbsp;<asp:DropDownList ID="ddlMetodopago" runat="server" DataTextField="Nombre_TARJ" DataValueField="IDTarjeta_TARJ" OnSelectedIndexChanged="ddlMetodopago_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:DropDownList ID="ddlCuotas" runat="server">
    </asp:DropDownList>
    <asp:GridView ID="grdCompra" runat="server" HorizontalAlign="Right" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" CssClass="text-center">
        <Columns>
            <asp:ImageField DataImageUrlField="RutaImagen">
                <ControlStyle Width="100" Height ="50" />
            </asp:ImageField>
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" FooterText="Total:" />
        </Columns>
    </asp:GridView>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblNrotarjeta" runat="server" Text="Nro Tarjeta"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtNrotarjeta" runat="server" OnTextChanged="txtNrotarjeta_TextChanged" ToolTip="Solo números, no puede quedar vacío"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDireccion" runat="server" Text="Direccion de envío"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlDireccion" runat="server" OnSelectedIndexChanged="ddlDireccion_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblEnvio" runat="server" Text="Costo de envío"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrecioEnvio" runat="server"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtnCancelar" runat="server" OnClick="lbtnCancelar_Click">Cancelar compra</asp:LinkButton>
    

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbtnComprar" runat="server" OnClick="lbtnComprar_Click">Confirmar compra</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        

</asp:Content>
