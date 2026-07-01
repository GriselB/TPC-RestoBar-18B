<%@ Page Title="Asignación de Mesas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="RestoWeb.Mesas.Asignaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Asignación de Mesas</h4>
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="btnActualizar_Click" />
    </div>

    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
    <asp:Label ID="lblExito" runat="server" CssClass="alert alert-success d-block" Visible="false" />

    <asp:GridView ID="dgvAsignaciones" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="IdMesa">
        <Columns>
            <asp:BoundField HeaderText="Mesa" DataField="NumeroMesa" />
            <asp:BoundField HeaderText="Descripción" DataField="DescripcionMesa" />
            <asp:BoundField HeaderText="Mesero actual" DataField="MeseroActual" />
            <asp:TemplateField HeaderText="Asignar mesero">
                <ItemTemplate>
                    <div class="d-flex gap-2 align-items-center">
                        <asp:DropDownList ID="ddlMesero" runat="server" CssClass="form-select" />
                        <asp:Button ID="btnAsignar" runat="server" Text="Asignar" CssClass="btn btn-sm btn-dark" OnClick="btnAsignar_Click" />
                        <asp:Button ID="btnQuitarAsignacion" runat="server" Text="Quitar asignación" CssClass="btn btn-sm btn-danger" OnClick="btnQuitarAsignacion_Click" Visible="false" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
