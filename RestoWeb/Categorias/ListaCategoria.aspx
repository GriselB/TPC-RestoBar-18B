<%@ Page Title="categoria" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="ListaCategoria.aspx.cs" Inherits="RestoWeb.Categorias.ListaCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Categorias</h4>
        <a href="FormularioCategoria.aspx" class="btn btn-dark">+ Nueva Categoria</a>
    </div>
     <asp:Label 
        ID="lblError" 
        runat="server" 
        CssClass="alert alert-danger d-block" 
        Visible="false">
    </asp:Label>
    <asp:GridView ID="dgvCategoria" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="dgvCategoria_RowCommand" >
        <Columns>
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href="FormularioCategoria.aspx?id=<%# Eval("Id") %>" class="btn btn-sm btn-secondary">Editar</a>
                    <asp:Button runat="server" Text="Baja" CssClass="btn btn-sm btn-danger"  CommandName="Baja" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('¿Estás seguro que querés eliminar esta Categoria?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>