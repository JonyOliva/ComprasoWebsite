<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmSignUp.aspx.cs" Inherits="ArvoProjectWebsite.WebForms.frmSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../Assets/Styles/Main.css" rel="stylesheet" />
    <link href="/Assets/Styles/usuario.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="container-fluid fondoceleste">
        <div class="row mb-3">
            <div class="col mt-2"> <h3 class="text-center">Registrar Usuario</h3></div>
            </div>
        <div class="row mb-3">
            <div class="col-5 text-right"> Mail:</div>
            <div class="col"><asp:TextBox ID="txtMailSignUp" runat="server" TextMode="Email" Width="280px" ToolTip="Ingrese un email válido. Formato aaa@bbb.ccc"></asp:TextBox>
              <asp:Label ID="lblMailSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
        <div class="row mb-3">
            <div class="col-5 text-right"> Nombre:</div>
            <div class="col"><asp:TextBox ID="txtNombreSignUp" runat="server" Width="280px" ToolTip="Ingrese su nombre."></asp:TextBox>
              <asp:Label ID="lblNombreSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
          <div class="row mb-3">
            <div class="col-5 text-right"> Apellido:</div>
            <div class="col"> <asp:TextBox ID="txtApellidoSignUp" runat="server" Width="280px" ToolTip="Ingrese su apellido."></asp:TextBox>
              <asp:Label ID="lblApellidoSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
         <div class="row mb-3">
            <div class="col-5 text-right">   Contraseña:</div>
            <div class="col"> <asp:TextBox ID="txtContraSingUp" runat="server" TextMode="Password" ToolTip="Ingrese su contraseña."></asp:TextBox>
              <asp:Label ID="lblContraSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
        <div class="row mb-3">
            <div class="col-5 text-right">   Repetir Contraseña:</div>
            <div class="col"><asp:TextBox ID="txtRepContraSignUp" runat="server" TextMode="Password" ToolTip="Ingrese nuevamente su contraseña."></asp:TextBox>
              <asp:Label ID="lblRepContraSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
          <div class="row mb-3">
            <div class="col-5 text-right">  C.U.I.T/C.U.I.L:</div>
            <div class="col"><asp:TextBox ID="txtCuit1SignUp" runat="server" Width="35px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
              -<asp:TextBox ID="txtDniSignUp" runat="server" Width="135px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
               -<asp:TextBox ID="txtCuit2SignUp" runat="server" Width="35px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
                <asp:Label ID="lblCuitSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
 <div class="row mb-3">
            <div class="col-5 text-right">    Fecha Nacimiento:</div>
            <div class="col"> <asp:TextBox ID="txtFechaSignUp" runat="server" Width="173px" TextMode="Date"></asp:TextBox>
              <asp:Label ID="lblFechaSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
        <div class="row mb-3">
            <div class="col-5 text-right">    Nro. Cel/Tel:</div>
            <div class="col"> <asp:TextBox ID="txtTelefonoSignUp" runat="server" ></asp:TextBox>
              <asp:Label ID="lblTelefonoSignUp" runat="server" CssClass="msjError"></asp:Label></div>
        </div>
           <div class="row mt-2">
            <div class="col text-center">    
                <asp:Button ID="btnRegistrarSignUp" runat="server" OnClick="btnRegistrarSignUp_Click" CssClass="btnlogin bold bg-azul" Text="Registrar" />
            </div>
          
                    </div>
        <div class="row">
            <br />
        </div>
    </div>
    
 
 
 

</asp:Content>
