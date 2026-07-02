<%@ Page Title="Pedido en Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidoEnCurso.aspx.cs" Inherits="RestoWeb.Pedidos.PedidoEnCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Pedido en curso</h4>
        <asp:Button ID="btnCerrarPedido" runat="server" Text="Cerrar pedido" CssClass="btn btn-danger" OnClick="btnCerrarPedido_Click" />
    </div>

    <h3>
        <asp:Label ID="lblMesa" runat="server" Text="Mesa" />
    </h3>

    <div class="mb-3">
        <asp:Label ID="lblDatosPedido" runat="server" CssClass="text-muted" />
    </div>

    <%-- Grilla con el detalle del pedido --%>
    <asp:GridView ID="dgvPedidoEnCurso" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Insumo" DataField="Insumo.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio unit." DataField="PrecioUnitario" DataFormatString="{0:C}" />
            <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button
                        runat="server"
                        Text="Quitar"
                        CssClass="btn btn-sm btn-secondary"
                        CommandArgument='<%# Eval("Id") %>'
                        CausesValidation="false"
                        OnClick="btnQuitarInsumo_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <%-- Sección para agregar un insumo nuevo al pedido (oculta si el pedido ya está cerrado) --%>
    <div runat="server" id="pnlAgregarInsumo">

        <hr class="my-4" />
        <h5>Agregar insumo</h5>

        <asp:Label ID="lblErrorInsumo" runat="server" CssClass="alert alert-danger" Visible="false" />

        <div class="row g-2 align-items-start mb-3">

            <%-- Buscador de insumo --%>
            <div class="col-md-5">
                <label class="form-label">Insumo</label>

                <div class="input-group">
                    <asp:TextBox ID="txtBuscarInsumo" runat="server" CssClass="form-control" placeholder="Escribí el nombre del insumo..." AutoPostBack="true" OnTextChanged="txtBuscarInsumo_TextChanged" />
                    <asp:Button ID="btnBuscarInsumo" runat="server" Text="Buscar" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="btnBuscarInsumo_Click" />
                </div>

                <asp:HiddenField ID="hfIdInsumoSeleccionado" runat="server" />

                <%-- Resultado cuando hay una sola coincidencia --%>
                <div class="mt-1">
                    <asp:Label ID="lblInsumoEncontrado" runat="server" CssClass="badge" Visible="false" />
                </div>

                <%-- Resultado cuando hay varias coincidencias: un botón por insumo --%>
                <asp:Repeater ID="repInsumosEncontrados" runat="server" Visible="false">
                    <ItemTemplate>
                        <asp:Button
                            runat="server"
                            Text='<%# TextoInsumo(Container.DataItem) %>'
                            CssClass="btn btn-outline-dark btn-sm d-block w-100 text-start mb-1"
                            Style="white-space: normal;"
                            CommandArgument='<%# Eval("Id") %>'
                            CausesValidation="false"
                            OnClick="btnSeleccionarInsumo_Click" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <%-- Cantidad, con botones de suma y resta --%>
            <div class="col-auto ms-auto">
                <label class="form-label">Cantidad</label>
                <div class="input-group" style="max-width: 140px;">
                    <asp:Button ID="btnRestarCantidad" runat="server" Text="-" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="btnRestarCantidad_Click" />
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control text-center" Text="1" />
                    <asp:Button ID="btnSumarCantidad" runat="server" Text="+" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="btnSumarCantidad_Click" />
                </div>
            </div>

            <%-- Agregar insumo --%>
            <div class="col-auto">
                <label class="form-label d-block">&nbsp;</label>
                <asp:Button ID="btnAgregarInsumo" runat="server" Text="+ Agregar insumo" CssClass="btn btn-dark" CausesValidation="false" OnClick="btnAgregarInsumo_Click" />
            </div>

        </div>

    </div>

    <%-- Total del pedido --%>
    <div class="d-flex justify-content-end align-items-center mt-3">
        <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold" />
    </div>

</asp:Content>
