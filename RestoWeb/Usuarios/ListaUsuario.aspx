<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaUsuario.aspx.cs" Inherits="RestoWeb.Usuarios.ListaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Usuarios</h4>
        <a href="FormularioUsuario.aspx" class="btn btn-dark">+ Nuevo usuario</a>
    </div>

    <div class="row mb-3">
        <div class="col-3">
            <asp:DropDownList ID="ddlCampoBusqueda" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampoBusqueda_SelectedIndexChanged">
                <asp:ListItem Text="Nombre" Value="Nombre" />
                <asp:ListItem Text="Apellido" Value="Apellido" />
                <asp:ListItem Text="Usuario" Value="NombreUsuario" />
            </asp:DropDownList>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Inserte texto aquí" AutoPostBack="true" OnTextChanged="txtBusqueda_TextChanged" />
        </div>
        <div class="col-5 d-flex justify-content-end gap-2">
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                <asp:ListItem Text="Todos" Value="Todos" />
                <asp:ListItem Text="Activo" Value="Activo" />
                <asp:ListItem Text="Inactivo" Value="Inactivo" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged">
                <asp:ListItem Text="Todos" Value="0" />
                <asp:ListItem Text="Gerente" Value="1" />
                <asp:ListItem Text="Mesero" Value="2" />
            </asp:DropDownList>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="btnActualizar_Click" />
        </div>
    </div>

    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />

    <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Rol" DataField="Rol.Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href='FormularioUsuario.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-secondary">Editar</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>