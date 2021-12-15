<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmEliminarLibro.aspx.cs" Inherits="Prestasacion.wfrmEliminarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="frmhead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">

    <div class="container">
        <div class="card-header">
            <h1>Confirmación de eliminar</h1>
        </div>
        <div class="card">
            <div class="card-body">

                <h4 class="card-title">Titulo:</h4>
                <h6 class="card-subtitle">Clave:</h6>
                <h6 class="card-subtitle">Autor:</h6>
                <h6 class="card-subtitle">Categoria</h6>
                <p class="card-text">El libro sera Eliminado! Confirma la eliminacion</p>
                <asp:Button ID="btnEliminar" runat="server" Text="Button" CssClass="btn  btn-danger" />
                <asp:Button ID="btnRegresar" runat="server" Text="Button" CssClass="btn  btn-success" />
            </div>
        </div>



    </div>
</asp:Content>
