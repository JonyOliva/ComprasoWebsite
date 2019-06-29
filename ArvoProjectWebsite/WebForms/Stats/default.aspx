<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.Reportes._default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%--FORM DE REPORTES--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-secondary">
        <h4 class="text-light text-center">ESTADÍSTICAS</h4>
    </div>
    <br />
    <p>
        <asp:Button ID="btnProductos" runat="server" Text="Productos" CssClass="btn btn-primary ml-3" Font-Bold="True" OnClick="btnProductos_Click" />
        <asp:Button ID="btnVentas" runat="server" Text="Ventas" CssClass="btn btn-danger ml-3" Font-Bold="True" />
    </p>
    <asp:DropDownList ID="ddlFecha" runat="server"></asp:DropDownList>
    <asp:MultiView ID="MultiViewStats" runat="server">
        <asp:View ID="ViewProductos" runat="server">
            <div class ="text-center">
            <br />
            <h3>Venta de productos</h3>
            <br />
            <asp:Chart ID="StatsProdVentas" runat="server" Palette="None" PaletteCustomColors="4, 49, 180">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="Productos"></AxisX>
                        <AxisY Title="Cantidad"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
                </div>
        </asp:View>

        <asp:View ID="ViewVentas" runat="server">

        </asp:View>

    </asp:MultiView>

</asp:Content>
