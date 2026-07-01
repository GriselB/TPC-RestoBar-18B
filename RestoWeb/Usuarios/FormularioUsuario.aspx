<%@ Page Title="Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="RestoWeb.Usuarios.FormularioUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" CssClass="h4 mb-4 d-block" />
    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre de usuario</label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Rol</label>
                <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select" />
            </div>
            <div class="mb-3">
                <asp:CheckBox ID="chkActivo" runat="server" Text=" Activo" Checked="true" Visible="false" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-dark" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnResetearPassword" runat="server" Text="Resetear contraseña" CssClass="btn btn-warning" OnClick="btnResetearPassword_Click" Visible="false" />
                <a href="ListaUsuario.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>