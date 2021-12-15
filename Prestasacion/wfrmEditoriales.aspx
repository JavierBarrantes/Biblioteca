<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEditoriales.aspx.cs" Inherits="Prestasacion.wfrmEditoriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container" id="|">
        <h1>Lista de Editoriales</h1>
        <%if (Session["_err"] != null) //
            {  %>
        <div class="alert alert-danger" role="alert">
            <%=Session["_err"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>

        <%   }%>        <% if (Session["_exito"] != null)
            {%>
        <div class="alert alert-success" role="alert">
            <%=Session["_exito"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <% Session["_exito"] = null;

            }%><%if (Session["_wrn"] != null)
            {  %>
        <div class="alert alert-warning" role="alert">
            <%=Session["_wrn"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>

        <% }%>
        <div class="row mt-3">
            <div class="col-auto">
                <asp:Label ID="Label1" runat="server" Text="Filtrar por Titulo"></asp:Label>
            </div>
            <div class||="col-auto ">
                <asp:TextBox ID="txtFiltrarNombre" runat="server" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
            </div>
            <div class="col-auto">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-secondary" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnLibroNuevo" runat="server" Text="Nuevo" CssClass="btn btn-secondary" OnClick="btnLibroNuevo_Click" />
            </div>
        </div>
        <asp:GridView ID="dvEditorial" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" AllowPaging="True" OnPageIndexChanging="dvEditorial_PageIndexChanging">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbEliminar" runat="server" CommandArgument='<%# Eval("ClaveEditorial").ToString() %>' OnCommand="lkbEliminar_Command">Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modificar">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModifcar" runat="server" CommandArgument='<%# Eval("ClaveEditorial").ToString() %>'>Modificar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="ClaveEditorial" HeaderText="Clave" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        
      
    </div>
    </asp:Content>
