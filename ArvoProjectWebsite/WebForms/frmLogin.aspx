<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ArvoProjectWebsite.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Iniciar Sesión</title>

    <link href="/Assets/Styles/usuario.css" rel="stylesheet" />
    <link href="/Assets/Styles/bootstrap/bootstrap.min.css" rel="stylesheet" />


</head>
<body class="fondogris">
    <form id="form1" runat="server">

        <div class="caja">
            <div class="container">
                <div class="row ml-1">
                    <a href="/default.aspx" id="logo">
                        <img src="../Assets/Images/compraso_l2.png" alt="logo" /></a>
                </div>
                <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewLogin" runat="server">

                        <div class="row text-center">
                            <div class="col bg-azul">
                                <h4 class="text-light">Iniciar Sesión</h4>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-5 text-right">Email:</div>
                            <div class="col">
                                <asp:TextBox ID="txtUsuario" runat="server" Width="220px" TextMode="Email" ToolTip="Ingrese un email válido. Formato aaa@bbb.ccc">
                                </asp:TextBox>
                                <asp:Label ID="lblAst1" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="row pt-2">
                            <div class="col-5 text-right">Contraseña:</div>
                            <div class="col">
                                <asp:TextBox ID="txtPass" runat="server" Width="220px" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="lblAst2" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="row pt-2">
                            <div class="col-9 text-right">
                                <asp:CheckBox ID="chrRecordar" runat="server" Text="&nbsp Recordar Usuario " />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <br />
                        </div>
                        <div class="row pt-2 align-items-lg-center text-center ">
                            <div class="col align-self-md-center">
                                <asp:Button ID="btnLogin" CssClass="btnlogin bg-azul" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                        <hr />

                        <div class="row">
                            <div class="col">
                                <asp:LinkButton ID="linkOlvido" runat="server" OnClick="linkOlvido_Click">¿Olvidó su contraseña?</asp:LinkButton>
                            </div>
                            <div class="col text-right">
                                ¿No está registrado? &nbsp<asp:LinkButton ID="linkRegistrar" runat="server" OnClick="linkRegistrar_Click">Registrarse</asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                        </div>

                    </asp:View>
                    <asp:View ID="viewPassLoss" runat="server">
                        <div class="row text-center">
                            <div class="col bg-azul">
                                <h4 class="text-light">Recuperar Contraseña</h4>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-5 text-right">Email:</div>
                            <div class="col">
                                <asp:TextBox ID="txtEmail" runat="server" Width="220px">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row pt-2">
                            <div class="col-5 text-right">C.U.I.T/C.U.I.L:</div>
                            <div class="col">
                                <asp:TextBox ID="txtCuit1SignUp" runat="server" Width="35px" ToolTip="No ingrese &quot;-&quot;." CausesValidation="True" ValidateRequestMode="Enabled"></asp:TextBox>
                                -<asp:TextBox ID="txtDniSignUp" runat="server" Width="135px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
                                -<asp:TextBox ID="txtCuit2SignUp" runat="server" Width="35px" ToolTip="No ingrese &quot;-&quot;."></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row mb-3">
                            <div class="col-5 text-right">Fecha Nacimiento:</div>
                            <div class="col">
                                <asp:TextBox ID="txtFechaSignUp" runat="server" Width="173px" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:Label ID="lblErrorView2" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <br />
                        </div>
                        <div class="row pt-2 align-items-lg-center text-center">
                            <div class="col align-self-md-center">
                                <asp:Button ID="SubmitLossPass" CssClass="btnlogin bg-azul" runat="server" Text="Recuperar" OnClick="SubmitLossPass_Click" />
                            </div>
                        </div>
                        <br />
                        <hr />
                        <div class="row">
                            <div class="col">
                                <asp:LinkButton ID="SubmitReturn" runat="server" OnClick="linkOlvido_Click">Regresar</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                    </asp:View>
                    <asp:View ID="showPass" runat="server">
                        <br />
                        <div class="row " id="rowPass">
                            <div class="col text-center">
                                <p style="font-size: xx-large;">Su contraseña es: </p>
                                <asp:Label ID="lblpass" CssClass="text-success border-success border" Style="font-size: xx-large;" runat="server" Visible="False"></asp:Label>
                            </div>
                            <br />
                        </div>
                        <br />
                        <div class="row">
                            <div class="col text-center">
                                <asp:LinkButton ID="submitAceptar" runat="server" OnClick="linkOlvido_Click">Aceptar</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <br />
                    </asp:View>
                </asp:MultiView>

            </div>

        </div>

    </form>
    <p>
        &nbsp;
    </p>
</body>
</html>
