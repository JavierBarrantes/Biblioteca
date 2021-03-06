<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEliminarLibro.aspx.cs" Inherits="Prestasacion.wfrmEliminarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="frmhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">

    <div class="container">
        <div class="card-header">
            <h1>Confirmación de eliminar</h1>
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
                    <h4 class="card-title">Titulo: <%=ViewState["_titulo"]%></h4>
                    <h6 class="card-subtitle">Clave: <%=Session["_claveLibro"]%></h6>
                    <h6 class="card-subtitle">Autor: <%=ViewState["_autor"]%></h6>
                    <h6 class="card-subtitle">Categoria: <%=ViewState["_categoria"]%></h6>
                    <p class="card-text">El libro sera Eliminado! Confirma la eliminacion</p>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn  btn-danger" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn  btn-success" OnClick="btnRegresar_Click" />
                </div>
            </div>

        </div>



    </div>
</asp:Content>
