<%@ Page Language="C#" Title="Menú Administración" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMenuAdmin.aspx.cs" Inherits="ArvoProjectWebsite.frmMenuAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="bg-secondary">
        <h4 class="text-light text-center">Menú Administrador</h4>
    </div>
     <br />
    <p>
        
            <asp:Button ID="btnProductos" runat="server" Text="Productos" CssClass="btn btn-primary ml-3" OnClick="btnProductos_Click" Font-Bold="True" />
              <asp:Button ID="btnMarcas" runat="server" Text="Marcas" CssClass="btn btn-success ml-3" OnClick="btnMarcas_Click" Font-Bold="True" />
             <asp:Button ID="btnVentas" runat="server" Text="Ventas" CssClass="btn btn-danger ml-3" OnClick="btnVentas_Click" Font-Bold="True" />
       
       </p>
  
    <div>
        <asp:MultiView ID="MultiViewAdmin" runat="server">
            <asp:View ID="ViewProductos" runat="server">
                
                <div class="container-fluid mb-3">
                <asp:GridView ID="GridProductos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" CellPadding="3" CellSpacing="2" DataKeyNames="IDProducto" DataSourceID="SqlDataSource_Prod">
                    <Columns>
                        <asp:BoundField DataField="IDProducto" HeaderText="ID Producto" ReadOnly="True" SortExpression="IDProducto" />
                        <asp:BoundField DataField="Nombre_PROD" HeaderText="Nombre" SortExpression="Nombre_PROD" />
                        <asp:BoundField DataField="Stock_PROD" HeaderText="Stock" SortExpression="Stock_PROD" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Precio_PROD" HeaderText="Precio" SortExpression="Precio_PROD" DataFormatString="{0:C}" >
                        <ControlStyle Width="80px" />
                        <HeaderStyle Width="90px" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descuento_PROD" HeaderText="Descuento" SortExpression="Descuento_PROD" DataFormatString="{0}%" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CheckBoxField DataField="ACTIVO" HeaderText="ACTIVO" SortExpression="ACTIVO" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:CheckBoxField>
                        <asp:BoundField DataField="Descripcion_PROD" HeaderText="Descripción" SortExpression="Descripcion_PROD" />
                        <asp:BoundField DataField="RutaImagen" HeaderText="RutaImagen" SortExpression="RutaImagen" Visible="False" />
                        <asp:ImageField DataImageUrlField="RutaImagen" HeaderText="Imagen">
                            <ControlStyle CssClass="miniatura" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:ImageField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <FooterStyle BackColor="Navy" ForeColor="MidnightBlue" />
                    <HeaderStyle BackColor="SteelBlue" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="AliceBlue" HorizontalAlign="Center" />
                    <RowStyle BackColor="WhiteSmoke" ForeColor="Black" />
                    <SelectedRowStyle BackColor="Turquoise" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="CadetBlue" />
                    <SortedAscendingHeaderStyle BackColor="CadetBlue" />
                    <SortedDescendingCellStyle BackColor="CadetBlue" />
                    <SortedDescendingHeaderStyle BackColor="CadetBlue" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource_Prod" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionStringLocal %>" SelectCommand="SELECT [IDProducto], [Nombre_PROD], [Stock_PROD], [Precio_PROD], [Descuento_PROD], [ACTIVO], [Descripcion_PROD], [RutaImagen] FROM [PRODUCTOS]"></asp:SqlDataSource>
                </div>

            </asp:View>

            <asp:View ID="ViewMarcas" runat="server">
                <div class="container-fluid mb-3">
                <asp:GridView ID="GridMarcas" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IDMarca" DataSourceID="SqlDataSource_Marcas" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="IDMarca" HeaderText="IDMarca" ReadOnly="True" SortExpression="IDMarca" />
                        <asp:BoundField DataField="Nombre_MARCA" HeaderText="Nombre" SortExpression="Nombre_MARCA" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
               
                <asp:SqlDataSource ID="SqlDataSource_Marcas" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionStringLocal %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [IDMarca], [Nombre_MARCA] FROM [MARCAS]"></asp:SqlDataSource>
               </div>


            </asp:View>

            <asp:View ID="ViewVentas" runat="server">
                 <div class="container-fluid mb-3">
                <asp:GridView ID="GridVentas" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IDVenta" DataSourceID="SqlDataSource_Ventas" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="IDVenta" HeaderText="IDVenta" InsertVisible="False" ReadOnly="True" SortExpression="IDVenta" />
                        <asp:BoundField DataField="NroTarjeta_VENTA" HeaderText="NroTarjeta_VENTA" SortExpression="NroTarjeta_VENTA" />
                        <asp:BoundField DataField="IDUsuario_VENTA" HeaderText="IDUsuario_VENTA" SortExpression="IDUsuario_VENTA" />
                        <asp:BoundField DataField="CodDirreccion_VENTA" HeaderText="CodDirreccion_VENTA" SortExpression="CodDirreccion_VENTA" />
                        <asp:BoundField DataField="Descuento_VENTA" HeaderText="Descuento_VENTA" SortExpression="Descuento_VENTA" />
                        <asp:BoundField DataField="Total_VENTA" HeaderText="Total_VENTA" SortExpression="Total_VENTA" />
                        <asp:BoundField DataField="IDEnvio_VENTA" HeaderText="IDEnvio_VENTA" SortExpression="IDEnvio_VENTA" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource_Ventas" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionStringLocal %>" SelectCommand="SELECT * FROM [VENTAS]"></asp:SqlDataSource>
            </div>
                     </asp:View>

        </asp:MultiView>
       
    </div>



</asp:Content>