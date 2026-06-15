<%@ Page Title="Insumos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaInsumos.aspx.cs" Inherits="RestoWeb.Insumos.ListaInsumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Insumos</h4>
        <a href="FormularioInsumos.aspx" class="btn btn-dark">+ Nuevo Insumo</a>
    </div>

    <asp:GridView ID="dgvInsumos" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="dgvInsumos_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
            
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href='FormularioInsumos.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-secondary">Editar</a>
                     <asp:Button ID="btnBaja" runat="server" Text="Baja" CssClass="btn btn-sm btn-danger" CommandName="Baja" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('¿Estás seguro que querés eliminar este insumo?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
