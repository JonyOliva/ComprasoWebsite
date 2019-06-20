﻿<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMenuUsuario.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.frmMenuUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Assets/Styles/usuario.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <h4 class="text-light text-center bg-secondary"> MENÚ USUARIO</h4>
       
    <p>
        <asp:Label ID="lblNombreMenuUsuario" runat="server"></asp:Label>
    </p>
    <p>
        DNI:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDniMenuUsuario" runat="server"></asp:Label>
    </p>
    <p>
        EMAIL:&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMailMenuUsuario" runat="server"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="lbtnDireccionesMenuUsuario" runat="server" OnClick="lbtnDireccionesMenuUsuario_Click"><i class="fas fa-map-marker-alt"></i>&nbsp Direcciones</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnMdPMenuUsuario" runat="server" OnClick="lbtnMdPMenuUsuario_Click"><i class="far fa-credit-card"></i>&nbsp Medios de Pago</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnComprasMenuUsuario" runat="server" OnClick="lbtnComprasMenuUsuario_Click"><i class="fas fa-shopping-basket"></i>&nbsp Compras</asp:LinkButton>
    </p>
    

        <div class="tituloUsuario mb-2 bg-danger"> <asp:Label ID="lblMenuUsuario" runat="server" CssClass="text-light bold"></asp:Label></div>
       

    
    <div class="mt-1 mb-3">

        <asp:GridView ID="grdMenuUsuario" horizontalalign="Center" runat="server" AutoGenerateDeleteButton="True" CellPadding="15"  OnRowDeleted="grdMenuUsuario_RowDeleted"  OnRowDeleting="grdMenuUsuario_RowDeleting">
            <EditRowStyle BackColor="#3366FF" />
        </asp:GridView>
    </div>
</asp:Content>
