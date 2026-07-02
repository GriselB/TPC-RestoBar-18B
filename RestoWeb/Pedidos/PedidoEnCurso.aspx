<%@ Page Title="Pedido en Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidoEnCurso.aspx.cs" Inherits="RestoWeb.Pedidos.PedidoEnCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Pedido en curso</h4>

        <asp:Button
            ID="btnCerrarPedido"
            runat="server"
            Text="Cerrar pedido"
            CssClass="btn btn-danger"
            OnClick="btnCerrarPedido_Click" />
    </div>

    <h3>
        <asp:Label ID="lblMesa" runat="server" Text="Mesa" />
    </h3>

    <div class="mb-3">
        <asp:Label
            ID="lblDatosPedido"
            runat="server"
            CssClass="text-muted" />
    </div>

    <asp:GridView
        ID="dgvPedidoEnCurso"
        runat="server"
        CssClass="table"
        AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="Insumo" DataField="Insumo.Nombre" />

            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />

            <asp:BoundField
                HeaderText="Precio unit."
                DataField="PrecioUnitario"
                DataFormatString="{0:C}" />

            <asp:BoundField
                HeaderText="Subtotal"
                DataField="Subtotal"
                DataFormatString="{0:C}" />

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

    <hr class="my-4" />

    <h5>Agregar insumo</h5>

    <div class="row g-2 align-items-end mb-3">

        <div class="col-md-3">
            <label class="form-label">Cantidad</label>
            <div class="input-group">
                <asp:Button ID="btnRestarCantidad" runat="server" Text="-" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="btnRestarCantidad_Click" />
                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control text-center" Text="1" />
                <asp:Button ID="btnSumarCantidad" runat="server" Text="+" CssClass="btn btn-outline-secondary" CausesValidation="false" OnClick="btnSumarCantidad_Click" />
            </div>
        </div>

    </div>

    <div class="d-flex justify-content-between align-items-center mt-3">
        <asp:Button
            ID="btnAgregarInsumo"
            runat="server"
            Text="+ Agregar insumo"
            CssClass="btn btn-dark"
            OnClick="btnAgregarInsumo_Click" />

        <asp:Label
            ID="lblTotal"
            runat="server"
            CssClass="fw-bold" />
    </div>

</asp:Content>
