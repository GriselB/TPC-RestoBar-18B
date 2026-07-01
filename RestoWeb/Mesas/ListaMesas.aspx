<%@ Page Title="Mesas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaMesas.aspx.cs" Inherits="RestoWeb.Mesas.ListaMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Mesas</h4>
        <a href="FormularioMesa.aspx" class="btn btn-dark">+ Nueva mesa</a>
    </div>

    <div class="row mb-3">
        <div class="col-3">
            <asp:DropDownList ID="ddlCampoBusqueda" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampoBusqueda_SelectedIndexChanged">
                <asp:ListItem Text="Número" Value="Numero" />
                <asp:ListItem Text="Descripción" Value="Descripcion" />
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
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="btnActualizar_Click" />
        </div>
    </div>

    <asp:GridView ID="dgvMesas" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href='FormularioMesa.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-secondary">Editar</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>