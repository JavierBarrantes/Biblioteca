<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmMantenimientoEditorial.aspx.cs" Inherits="Prestasacion.wfrmListaEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">

   <div class="container">
       <div class="row mt-3">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" Text="Clave Editorial"></asp:Label>
                <asp:TextBox ID="txtClaveEditorial"  runat="server" CssClass="form-control" ValidationGroup="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe agregar una clave de Editorial" ControlToValidate="txtClaveEditorial" ValidationGroup="3" Text="*" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
            </div>
            <div class="col-4">
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ValidationGroup="3" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe agregar un Nombre de editorial" ControlToValidate="txtNombre" ValidationGroup="3" Text="*" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <asp:Button ID="btnRegresarE" runat="server" Text="Regresar" CssClass="btn btn-primary" OnClick="btnRegresarE_Click"  />
        <asp:Button ID="btnGuardarE" runat="server" Text="Guadar" CssClass="btn btn-warning" ValidationGroup="3" OnClick="btnGuardarE_Click"  />
        <% if (Session["_exito"] != null)
            {%>
        <div class="alert alert-success" role="alert">
            <%=Session["_exito"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <% Session["_exito"] = null;

             }%>
        
        <%-- ********************************** --%>
        <% if (Session["_wrn"] != null)
            {%>
        <div class="alert alert-warning" role="alert">
            <%=Session["_wrn"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <% Session["_wrn"] = null;
            }%>
        <%-- ********************************** --%>
        <% if (Session["_err"] != null)
            {%>
        <div class="alert alert-success" role="alert">
            <%=Session["_err"]%>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
        <% Session["_err"] = null;
            }%>
    </div>
   
</asp:Content>
