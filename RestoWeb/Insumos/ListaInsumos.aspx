<%@ Page Title="Insumos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaInsumos.aspx.cs" Inherits="RestoWeb.Insumos.ListaInsumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-3">
        <h4>Insumos</h4>
        <a href="FormularioInsumos.aspx" class="btn btn-dark">+ Nuevo Insumo</a>
    </div>

    <div class="mb-4">
        <div class="row g-2 align-items-end">

            <div class="col-md-4">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtFiltroNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="col-md-4">
                <label class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlFiltroCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

           <div class="col-md-2">
            <div class="form-check form-switch mb-2">
                <input 
                    class="form-check-input" 
                    type="checkbox" 
                    role="switch" 
                    id="chkStockCero" 
                    runat="server" />

                <label class="form-check-label" for="chkStockCero">
                    Stock 0
                </label>
            </div>
        </div>

            <div class="col-md-2">
                <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn btn-primary w-100" OnClick="btnFiltrar_Click" />
            </div>

        </div>
    </div>

    <asp:GridView ID="dgvInsumos" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="dgvInsumos_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            
            <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo" />
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
