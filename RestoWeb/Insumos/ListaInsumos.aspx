<%@ Page Title="Insumos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaInsumos.aspx.cs" Inherits="RestoWeb.Insumos.ListaInsumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Insumos</h4>
        <a href="FormularioInsumos.aspx" class="btn btn-dark">+ Nuevo Insumo</a>
    </div>

    <asp:GridView ID="dgvInsumos" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href="FormularioInsumos.aspx" class="btn btn-sm btn-secondary">Editar</a>
                    <asp:Button runat="server" Text="Baja" CssClass="btn btn-sm btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>