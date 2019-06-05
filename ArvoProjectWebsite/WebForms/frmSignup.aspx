<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmSignUp.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.frmSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Assets/Styles/Main.css" rel="stylesheet" />
    <link href="/Assets/Styles/usuario.css" rel="stylesheet" />
    
    <p class="text-left">
        &nbsp;</p>
    <p class="text-left" style="text-decoration: underline; margin-left: 120px">
        REGISTRAR USUARIO</p>
    <p class="text-left" >
        &nbsp;</p>
    <p class="text-left">
        Mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtMailSignUp" runat="server" TextMode="Email" Width="273px" ToolTip="Ingrese un email válido. Formato aaa@bbb.ccc"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMailSignUp" runat="server" Font-Italic="True" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
    </p>
    <p class="text-left">
        Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtNombreSignUp" runat="server" Width="280px" ToolTip="Ingrese su nombre."></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblNombreSignUp" runat="server" style="font-size: small; font-style: italic; color: #CC0000"></asp:Label>
    </p>
    <p class="text-left">
        Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtApellidoSignUp" runat="server" Width="279px" ToolTip="Ingrese su apellido."></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblApellidoSignUp" runat="server" style="font-style: italic; color: #CC0000; font-size: small"></asp:Label>
    </p>
    <p class="text-left">
        Contraseña:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtContraSingUp" runat="server" TextMode="Password" ToolTip="Ingrese su contraseña."></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblContraSignUp" runat="server" style="font-size: small; font-style: italic; color: #CC0000"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="text-left">
        Repetir Contraseña:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtRepContraSignUp" runat="server" TextMode="Password" ToolTip="Ingrese nuevamente su contraseña."></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRepContraSignUp" runat="server" style="font-size: small; font-style: italic; color: #CC0000"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="text-left">
        C.U.I.T/C.U.I.L:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCuit1SignUp" runat="server" Width="35px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
&nbsp;-
        <asp:TextBox ID="txtDniSignUp" runat="server" Width="135px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
&nbsp;-
        <asp:TextBox ID="txtCuit2SignUp" runat="server" Width="25px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCuitSignUp" runat="server" style="font-style: italic; color: #CC0000; font-size: small"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="text-left">
        Fecha Nacimiento:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtFechaSignUp" runat="server" Width="173px" TextMode="Date"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblFechaSignUp" runat="server" style="font-style: italic; font-size: small; color: #CC0000"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="text-left">
        Nro. Cel/Tel:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTelefonoSignUp" runat="server" ></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblTelefonoSignUp" runat="server" style="color: #CC0000; font-size: small; font-style: italic"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p class="text-left">
        &nbsp;</p>
    <p class="text-left">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnRegistrarSignUp" runat="server" OnClick="btnRegistrarSignUp_Click" Text="Registrar" />
    </p>


</asp:Content>
