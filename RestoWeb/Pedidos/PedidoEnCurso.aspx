<%@ Page Title="Pedido en Curso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PedidoEnCurso.aspx.cs" Inherits="RestoWeb.Pedidos.PedidoEnCurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Pedido en curso</h4>
       <asp:Button ID="btnCerrarPedido" runat="server" Text="Cerrar pedido" CssClass="btn btn-danger" OnClick="btnCerrarPedido_Click" />
        
    </div>
    <h3>Mesa 3</h3>
    <div class="mb-3">
        <asp:Label
            ID="lblDatosPedido"
            runat="server"
            CssClass="text-muted"
            Text="Apertura: 20:30 hs | Mesero: Maxi Programa" />
    </div>
    <asp:GridView ID="dgvPedidoEnCurso" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Inusmo" DataField="Insumo" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio unit." DataField="Subtotal" />
            <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Quitar" CssClass="btn btn-sm btn-secondary" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="d-flex justify-content-between align-items-center mt-3">
        <asp:Button ID="btnAgregarInsumo" runat="server" Text="+ Agregar insumo" CssClass="btn btn-dark" OnClick="btnAgregarInsumo_Click" />
        <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold" />

    </div>
</asp:Content>
