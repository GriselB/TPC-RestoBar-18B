<%@ Page Title=""  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="FormularioInsumos.aspx.cs" Inherits="RestoWeb.Insumos.FormularioInsumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" CssClass="h4 mb-4 d-block" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Stock</label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria"  runat="server" CssClass="form-select" ></asp:DropDownList> 
           </div>
            <div class="mb-3">
                <asp:CheckBox ID="chkActivo" runat="server" Text=" Activo" Checked="true" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-dark" OnClick="btnGuardar_Click" />
                <a href="ListaInsumos.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>