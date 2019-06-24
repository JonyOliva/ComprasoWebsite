<%@ Page Language="C#" Title="Menú Administración" MasterPageFile="~/WebForms/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMenuAdmin.aspx.cs" Inherits="ArvoProjectWebsite.frmMenuAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <div class="bg-secondary">
        <h4 class="text-light text-center">MENÚ ADMINISTRADOR</h4>
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
               
                 <p>
                     <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-plus-circle"></i> &nbsp Agregar producto</asp:LinkButton></p>
                <div class="container-fluid mb-3">

 <asp:Table ID="AgregarProducto" runat="server" Width="80%" Visible="False" CssClass="mb-3">
     <asp:TableRow runat="server" TableSection="TableHeader" BackColor="#3366FF" Font-Bold="True" ForeColor="White" CssClass="text-center">
         <asp:TableCell runat="server">Id Producto</asp:TableCell>
         <asp:TableCell runat="server">Nombre</asp:TableCell>
         <asp:TableCell runat="server">Stock</asp:TableCell>
         <asp:TableCell runat="server">Precio</asp:TableCell>
         <asp:TableCell runat="server">Descuento</asp:TableCell>
         <asp:TableCell runat="server">ACTIVO</asp:TableCell>
         <asp:TableCell runat="server">Descripción</asp:TableCell>
         <asp:TableCell runat="server"></asp:TableCell>
     </asp:TableRow>
                        <asp:TableRow runat="server" CssClass="text-center">
                            <asp:TableCell CssClass="campo" runat="server">
                                <asp:TextBox ID="txtIdProd" runat="server"></asp:TextBox>
</asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtNombreProd" runat="server"></asp:TextBox>
</asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
</asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
</asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtDescuento" runat="server"></asp:TextBox>
</asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:CheckBox ID="chkActivo" runat="server" />
</asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                            

</asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                            

</asp:TableCell>
                            
                        </asp:TableRow>
                    </asp:Table>
               <%-- <asp:GridView ID="GridProductos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="Silver" BorderStyle="Solid" BorderWidth="2px" CellPadding="3" CellSpacing="2" DataKeyNames="IDProducto" DataSourceID="SqlDataSource_Prod" OnRowEditing="GridProductos_RowEditing" OnRowUpdating="GridProductos_RowUpdating" AutoGenerateEditButton="True" Visible="false">
                    <Columns>
                        <asp:TemplateField HeaderText="ID Producto" SortExpression="IDProducto">
                            <EditItemTemplate>
                                <asp:Label ID="lblID2" runat="server" Text='<%# Eval("IDProducto") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("IDProducto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre_PROD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock" SortExpression="Stock_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind("Stock_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStock" runat="server" Text='<%# Bind("Stock_PROD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio" SortExpression="Precio_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("Precio_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("Precio_PROD", "{0:C}") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="80px" />
                            <HeaderStyle Width="90px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descuento" SortExpression="Descuento_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescuento" runat="server" Text='<%# Bind("Descuento_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescuento" runat="server" Text='<%# Bind("Descuento_PROD", "{0}%") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACTIVO" SortExpression="ACTIVO">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkActivo" runat="server" Checked='<%# Bind("ACTIVO") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActivo" runat="server" Checked='<%# Bind("ACTIVO") %>' Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripción" SortExpression="Descripcion_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescrip" runat="server" Text='<%# Bind("Descripcion_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescrip" runat="server" Text='<%# Bind("Descripcion_PROD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RutaImagen" SortExpression="RutaImagen" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="lblRuta2" runat="server" Text='<%# Bind("RutaImagen") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRuta" runat="server" Text='<%# Bind("RutaImagen") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ImageField DataImageUrlField="RutaImagen" HeaderText="Imagen">
                            <ControlStyle CssClass="miniatura" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:ImageField>
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
                <asp:SqlDataSource ID="SqlDataSource_Prod" runat="server" ConnectionString="<%$ ConnectionStrings:ComprasoBDConnectionStringLocal %>" SelectCommand="SELECT [IDProducto], [Nombre_PROD], [Stock_PROD], [Precio_PROD], [Descuento_PROD], [ACTIVO], [Descripcion_PROD], [RutaImagen] FROM [PRODUCTOS]" 
                    UpdateCommand="UPDATE [Productos] SET [Nombre_PROD] =  @NombreProd, [Descripcion_PROD] = @Descripcion, 
[Stock_PROD] = @Stock, [Precio_PROD] = @Precio, [Descuento_PROD] = @Descuento_PROD,[ACTIVO] = @Activo
WHERE [IDProducto] = @IdProd" >
                    <UpdateParameters>
    <asp:Parameter Name="NombreProd" Type="String" />
    <asp:Parameter Name="Descripcion" Type="String" />
    <asp:Parameter Name="Stock" Type="Int32" />
    <asp:Parameter Name="Precio" Type="Decimal" />
    <asp:Parameter Name="Descuento" Type="Decimal" />
    <asp:Parameter Name="Activo" Type="Boolean" />
<asp:Parameter Name="IdProd" Type="String" />
</UpdateParameters>
                </asp:SqlDataSource>--%>
                    <asp:GridView ID="grdProd" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="grdProd_RowCancelingEdit" OnRowEditing="grdProd_RowEditing" OnRowUpdating="grdProd_RowUpdating">
                        <Columns>
                        <asp:TemplateField HeaderText="ID Producto" SortExpression="IDProducto">
                            <EditItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("IDProducto") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("IDProducto") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre_PROD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock" SortExpression="Stock_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind("Stock_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStock" runat="server" Text='<%# Bind("Stock_PROD") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio" SortExpression="Precio_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("Precio_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPrecio" runat="server" Text='<%# Bind("Precio_PROD", "{0:C}") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="80px" />
                            <HeaderStyle Width="90px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descuento" SortExpression="Descuento_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescuento" runat="server" Text='<%# Bind("Descuento_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescuento" runat="server" Text='<%# Bind("Descuento_PROD", "{0}%") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACTIVO" SortExpression="ACTIVO">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkActivo" runat="server" Checked='<%# Bind("ACTIVO") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActivo" runat="server" Checked='<%# Bind("ACTIVO") %>' Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descripción" SortExpression="Descripcion_PROD">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescrip" runat="server" Text='<%# Bind("Descripcion_PROD") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescrip" runat="server" Text='<%# Bind("Descripcion_PROD") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RutaImagen" SortExpression="RutaImagen" Visible="False">
                            <EditItemTemplate>
                                <asp:Label ID="lblRuta2" runat="server" Text='<%# Bind("RutaImagen") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRuta" runat="server" Text='<%# Bind("RutaImagen") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ImageField DataImageUrlField="RutaImagen" HeaderText="Imagen">
                            <ControlStyle CssClass="miniatura" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:ImageField>
                    </Columns>
                        
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                    <br />
                   
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
                <asp:GridView ID="GridVentas" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IDVenta" DataSourceID="SqlDataSource_Ventas" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="IDVenta" HeaderText="IDVenta" InsertVisible="False" ReadOnly="True" SortExpression="IDVenta" />
                        <asp:BoundField DataField="NroTarjeta_VENTA" HeaderText="NroTarjeta" SortExpression="NroTarjeta_VENTA" />
                        <asp:BoundField DataField="IDUsuario_VENTA" HeaderText="IDUsuario" SortExpression="IDUsuario_VENTA" />
                        <asp:BoundField DataField="CodDirreccion_VENTA" HeaderText="CodDirreccion" SortExpression="CodDirreccion_VENTA" />
                        <asp:BoundField DataField="Descuento_VENTA" HeaderText="Descuento" SortExpression="Descuento_VENTA" />
                        <asp:BoundField DataField="Total_VENTA" HeaderText="Total" SortExpression="Total_VENTA" />
                        <asp:BoundField DataField="IDEnvio_VENTA" HeaderText="IDEnvio" SortExpression="IDEnvio_VENTA" />
                        <asp:TemplateField HeaderText="Estado" SortExpression="Estado">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlEstado" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Estado") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                       
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