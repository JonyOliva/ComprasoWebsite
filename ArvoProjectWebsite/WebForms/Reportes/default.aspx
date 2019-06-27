<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.Reportes._default" %>

<%--FORM DE REPORTES--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-secondary">
        <h4 class="text-light text-center">MENÚ REPORTES</h4>
    </div>
    <br />
    <p>
        <asp:Button ID="btnProductos" runat="server" Text="Productos" CssClass="btn btn-primary ml-3" Font-Bold="True" />
        <asp:Button ID="btnMarcas" runat="server" Text="Usuarios" CssClass="btn btn-success ml-3" Font-Bold="True" />
        <asp:Button ID="btnVentas" runat="server" Text="Estadísticas" CssClass="btn btn-danger ml-3" Font-Bold="True" />
    </p>
</asp:Content>
