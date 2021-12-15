<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEliminarEditorial.aspx.cs" Inherits="Prestasacion.wfrmEliminarEditorial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="frmhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
       <div class="container">
        <div class="card-header">
            <h1>Confirmación de eliminanacion de Editorial</h1>
        </div>
        <div class="card">
            <div" class="row">
                <div>   

                </div>
                <div class="card-body">
                 <% if (Session["_err"] != null)
                  {%>
                            <div class="alert alert-success" role="alert">
                                <%=Session["_err"]%>
                                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            </div>
                         <% Session["_err"] = null;

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
                    <h4 class="card-title">Nombre: <%=ViewState["_nombre"]%></h4>
                    <h6 class="card-subtitle">Clave: <%=Session["_ClaveEdi"]%></h6>
                    <p class="card-text">La editorial sera Eliminada! Confirma la eliminacion</p>
                    <asp:Button ID="btnEliminarEditorial" runat="server" Text="Eliminar" CssClass="btn  btn-danger" OnClick="btnEliminarEditorial_Click"  />
                    <asp:Button ID="btnRegresarEditorial" runat="server" Text="Regresar" CssClass="btn  btn-success"  />
                </div>
            </div>

        </div>



    </div>
</asp:Content>
