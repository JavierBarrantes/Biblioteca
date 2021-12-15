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

        <%-- ALERTS--%>
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
        



        <div class="row mt-3">
            <div class="col-2">

                <asp:Label ID="Label1" runat="server" Text="Clave Libro"></asp:Label>
                <asp:TextBox ID="txtClaveLibro" runat="server" CssClass="form-control" ValidationGroup="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe agregar una clave de libro" ControlToValidate="txtClaveLibro" ValidationGroup="3" Text="*" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>


            </div>
            <div class="col-4">
                <asp:Label ID="Label2" runat="server" Text="Titulo"></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" ValidationGroup="3" OnTextChanged="txtTitulo_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe agregar un titulo" ControlToValidate="txtTitulo" ValidationGroup="3" Text="*" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
            </div>
            <div class="col-3">
                <asp:TextBox ID="txtIdAutor" runat="server" Visible="false" ValidationGroup="3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage=""
                    ControlToValidate="txtIdAutor" ValidationGroup="3" Text="*" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>
                <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>

                <div class="input-group mb-3">

                    <button class="btn btn-outline-secondary" type="button" id="btnAutor" data-bs-toggle="modal"
                        data-bs-target="#autorModal">
                        Buscar</button>
                    <asp:TextBox ID="txtAutor" runat="server" CssClass="form-control" ReadOnly="true" aria-describedby="btnAutor" ValidationGroup="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe agregar un autor"
                        ControlToValidate="txtAutor" ValidationGroup="3" Text="*" ForeColor="Red" Font-Italic="true"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="col-3">
                <asp:TextBox ID="txtIdCate" runat="server" Visible="false" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>

                <div class="input-group mb-3">
                    <button class="btn btn-outline-secondary"
                        type="button"
                        id="btnCategoria"
                        data-bs-toggle="modal"
                        data-bs-target="#cateModal">
                        Buscar</button>
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" ReadOnly="true"
                        aria-describedby="btnCategoria" ValidationGroup="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Debe agregar una categoria" Text="*" Font-Italic="True" ValidationGroup="3" ForeColor="Red" ControlToValidate="txtCategoria"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="vs1" runat="server" ValidationGroup="3" ForeColor="Red" Font-Italic="True" />
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guadar" CssClass="btn btn-warning" ValidationGroup="3" OnClick="btnGuardar_Click" />

    </div>
    <%--<%--   <%--fin del container--%><%--<%-- <%-- Modales --%>
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
                        <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%" AllowPaging="True" OnPageIndexChanging="gvAutores_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSelecionarAutor" runat="server" CommandArgument='<%# Eval("claveAutor").ToString() %>' OnCommand="lnkSelecionarAutor_Command">Selecionar</asp:LinkButton>
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



    <div class="modal" tabindex="-1" role="dialog" id="cateModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Categorias</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>Filtra categoria acá.</p>
                    <div class="col-auto">
                        <asp:Label ID="Label6" runat="server" Text="Categoria"></asp:Label>
                    </div>
                    <div class="row mt-3">
                        <div class="col-auto">

                            <asp:TextBox ID="txtFiltrarCate" runat="server" CssClass="form-control" ValidationGroup="2"></asp:TextBox>
                        </div>
                        <div class="col-auto">
                            <asp:Button ID="btnFiltrarCate" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrarCate_Click" ValidationGroup="2" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe agregar un dato" ValidationGroup="2" ControlToValidate="txtFiltrarCate"></asp:RequiredFieldValidator>
                        </div>
                        <asp:GridView ID="gvCate" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%" AllowPaging="True" OnPageIndexChanging="gvCate_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnbSelecionarCate" runat="server" CommandArgument='<%# Eval("claveCategoria").ToString() %>' OnCommand="lnbSelecionarCate_Command">Seleccionar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Categoria" DataField="descripcion" />
                                <asp:BoundField DataField="claveCategoria" Visible="False" />
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
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
