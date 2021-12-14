<%@ Page Title="" Language="C#" MasterPageFile="~/wfrmPlantilla.Master" AutoEventWireup="true" CodeBehind="wfrmLibros.aspx.cs" Inherits="Prestasacion.wfrmLibros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="frmhead" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="miScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="frmBody" runat="server">
    <div class="container">
        <div class="card-header text-center">
            <h1 class="justify-content-center">Mantenimiento de la Libros</h1>
            <%///TODO:Terminar%>
        </div>
        <br />
        <div class="row mt-3">
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" Text="Clave Libro"></asp:Label>
                <asp:TextBox ID="txtClaveLibro" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Label ID="Label2" runat="server" Text="Titulo"></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>

                <div class="input-group mb-3">

                    <button class="btn btn-outline-secondary" type="button" id="btnAutor" data-bs-toggle="modal"
                        data-bs-target="#autorModal">
                        Buscar</button>
                    <asp:TextBox ID="txtAutor" runat="server" CssClass="form-control" ReadOnly="true" aria-describedby="btnAutor"></asp:TextBox>
                </div>
            </div>
            <div class="col-3">
                <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>

                <div class="input-group mb-3">
                    <button class="btn btn-outline-secondary"
                        type="button"
                        id="btnCategoria"
                        data-bs-toggle="modal"
                        data-bs-target="#autorModal">
                        Buscar</button>
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" ReadOnly="true"
                        aria-describedby="btnCategoria"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guadar" CssClass="btn btn-warning" />

    </div>
    <%--fin del container--%>
    <%--<%-- <%-- Modales --%>
    <div class="modal" tabindex="-1" role="dialog" id="autorModal">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Buscar autor</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
                    </button>
                </div>
                <div class="modal-body">
                    <p>Filtra autores acá.</p>
                    <div class="col-auto">
                        <asp:Label ID="Label5" runat="server" Text="Autor"></asp:Label>
                    </div>
                    <div class="row mt-3">
                        <div class="col-auto">
                            <asp:TextBox ID="txtAutorModal" runat="server" CssClass="form-control" ValidationGroup="1"></asp:TextBox>
                        </div>

                        <div class="col-auto">
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" ValidationGroup="1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe agregar un dato" ValidationGroup="1" ControlToValidate="txtAutorModal"></asp:RequiredFieldValidator>
                        </div>
                        <br />
                        <br />
                        <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSelecionarAutor" runat="server" CommandArgument='<%# Eval("claveAutor").ToString() %>'>Selecionar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ClaveAutor" HeaderText="Clave Autor" Visible="False" />
                                <asp:BoundField DataField="apPaterno" HeaderText="Apellido" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>



    <div class="modal" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Moe</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>Modal body text goes here.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
