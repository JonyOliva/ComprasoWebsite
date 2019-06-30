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
    <div class="text-center container">
        <h4 class="text-primary">Ventas por mes</h4>
        <div class="border border-primary">
            <br />
            <div class="row">
                <div class="col-3"></div>
                <h5 class="col-3">Organizar por fecha: </h5>
                <asp:DropDownList CssClass="col-2" ID="ddlFecha" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFecha_SelectedIndexChanged"></asp:DropDownList>
                <div class="col-4"></div>
            </div>
            <br />
            <asp:Label ID="lblTotalMes" runat="server" Font-Bold="False" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <h5 class="text-info">Productos vendidos en el mes</h5>
            <br />
            <asp:Chart ID="StatsProdVentas" runat="server" Palette="None" PaletteCustomColors="4, 49, 180">
                <Series>
                    <asp:Series Name="Series1" ChartType="Bar"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="Productos"></AxisX>
                        <AxisY Title="Cantidad"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
        <br />
        <br />
        <h4 class="text-primary">Ingresos por año</h4>
        <div class="border border-primary">
            <br />
            <div class="row">
                <div class="col-3"></div>
                <h5 class="col-3">Organizar por fecha: </h5>
                <asp:DropDownList CssClass="col-1" ID="ddlAnio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
                <div class="col-4"></div>
            </div>
            <br />
            <asp:Label ID="lblTotalAnio" runat="server" Font-Bold="False" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <h5 class="text-info">Ingresos por mes</h5>
            <br />
            <asp:Chart ID="StatsVentasAnio" runat="server" EnableViewState="True" Height="400px" Width="500px">
                <Series>
                    <asp:Series Name="Series1" ChartType="Bar" XValueType="String"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="Mes" Interval="1"></AxisX>
                        <AxisY Title="Total"></AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>

</asp:Content>
