<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmProducto.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.frmProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col">
                
                <asp:Image ID="imgPrincipal" runat="server" style="max-height:500px;max-width:500px;height:auto;width:auto;" />
                <br />
                
            </div>
            <div class="col text-center">
                 <asp:Label ID="lblNomProd" CssClass="text-primary" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <br />
                <asp:Label ID="lblDescrip" CssClass="text-secondary" runat="server"></asp:Label>
                <br />
                <br />
                <p style="font-size:small; color:gray;">Precio en un pago</p>
                <asp:Label ID="lblStock" CssClass="text-warning" runat="server"></asp:Label>
                <div class="row align-items-center justify-content-center">
                    <asp:Label ID="lblPrecio" CssClass="col-3 text-muted" style="font-size:small; text-decoration: line-through;" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblPrecioFinal" CssClass="col-4 text-danger" style="font-size: xx-large;"  runat="server"></asp:Label>
                    <asp:Label ID="lblDesc" CssClass="col-3 text-success border border-success" runat="server" Visible="False"></asp:Label>
                </div>
 
                <br />
                <asp:ImageButton ID="btnComprar" runat="server" ImageUrl="~/Assets/Images/btnComprar.png" Width="30%" CommandName="IDProd" OnCommand="lbtnAñadircarr_Command" />

            </div>
        </div>


    </div>
</asp:Content>
