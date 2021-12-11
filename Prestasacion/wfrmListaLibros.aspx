<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmListaLibros.aspx.cs" Inherits="Prestasacion.wfrmListaLibros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="frmhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container text-xl-center">
        <div class="card-header text-center">
            <h1>Gestionar  libros</h1>
        </div>
        <br />

        <%if (Session["_err"] != null)
            {  %>
        <div class="alert alert-danger" role="alert">
            <%=Session["_err"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        
        <%   }%>


       <%if (Session["_wrn"] != null)
            {  %>
        <div class="alert alert-warning" role="alert">
            <%=Session["_wrn"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        
        <%   }%>


        <div class="row mt-3">
            <div class="col-auto">
                <asp:Label ID="Label1" runat="server" Text="Filtrar por Titulo"></asp:Label>
            </div>
            <div class="col-auto ">
                <asp:TextBox ID="txtFiltrarTitulo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-auto">
                <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />
        <asp:GridView ID="dtvLibros" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("Clave").ToString() %>'>Modifcar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("Clave").ToString() %>'>Borrar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Clave" HeaderText="Clave" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>
