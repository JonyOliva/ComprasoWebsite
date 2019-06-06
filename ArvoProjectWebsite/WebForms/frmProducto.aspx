<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmProducto.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.frmProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col">
                
                <asp:Image ID="imgPrincipal" runat="server" style="max-height:500px;max-width:600px;height:auto;width:auto;" />
                <br />
                
            </div>
            <div class="col">
                 <asp:Label ID="lblNomProd" CssClass="text-primary" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <br />
                <asp:Label ID="lblDescrip" CssClass="text-secondary" runat="server" Font-Bold="False"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="btnComprar" runat="server" ImageUrl="~/Assets/Images/btnComprar.png" Width="30%" />

            </div>
        </div>


    </div>
</asp:Content>
