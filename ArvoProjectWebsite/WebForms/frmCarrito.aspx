<%@ Page Language="C#" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmCarrito.aspx.cs" Inherits="ArvoProjectWebsite.frmCarrito" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Assets/Styles/Compras.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div align="center" class="align-content-center" style="min-height: 300px">
        <div style="background-color: #6666FF">
            <asp:Label ID="Label1" runat="server" Text="MI CARRITO" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
        </div>

        <br />

        <asp:GridView ID="grdCarrito" runat="server" OnRowCommand="grdCarrito_RowCommand" OnRowDeleting="grdCarrito_RowDeleting" AllowSorting="True" OnRowDataBound="grdCarrito_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" HorizontalAlign="Center" OnSorting="grdCarrito_Sorting" CssClass="text-center" OnRowCancelingEdit="grdCarrito_RowCancelingEdit" OnRowEditing="grdCarrito_RowEditing" OnRowUpdating="grdCarrito_RowUpdating" OnRowCreated="grdCarrito_RowCreated">
            <Columns>
                <asp:ImageField DataImageUrlField="RutaImagen">
                    <ControlStyle Height="100px" Width="150px" />
                </asp:ImageField>
                <asp:CommandField DeleteText="Quitar" ShowDeleteButton="True" />
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Width="66px"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        &nbsp;<asp:TextBox ID="txtCantidad" runat="server" Height="16px" Style="margin-top: 0px" Width="50px" TextMode="Number"></asp:TextBox>

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#0033CC" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblNocarrito" runat="server" Text="No posee ningún articulo en el carrito." Font-Names="Arial Black" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Calcular envio:"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlprecioEnvio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlprecioEnvio_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblMicarrito" runat="server" Font-Bold="True" Text="Costo: "></asp:Label>
        <asp:Label ID="lblPrecio" runat="server"></asp:Label>
    </div>
    <div align="Center" class="aling-content-center" style="position: relative; top: auto;">
        <asp:LinkButton CssClass="btn btn-primary" ID="lnkSeguircom" runat="server" OnClick="lnkSeguircom_Click" Font-Underline="False" OnClientClick="lnkSeguircom_Click" OnPreRender="lnkSeguircom_PreRender" Font-Names="Arial">Seguir comprando</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton CssClass="btn btn-success" ID="lnkComprar" runat="server" OnClick="lnkComprar_Click" Font-Underline="False" Font-Names="Arial">Realizar compra</asp:LinkButton>
    </div>
    <br />
</asp:Content>
