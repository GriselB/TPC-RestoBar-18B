<%@ Page Title="Mesas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaMesas.aspx.cs" Inherits="RestoWeb.Mesas.ListaMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Mesas</h4>
        <a href="FormularioMesa.aspx" class="btn btn-dark">+ Nueva mesa</a>
    </div>

    <asp:GridView ID="dgvMesas" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <a href='FormularioMesa.aspx?id=<%# Eval("Id") %>' class="btn btn-sm btn-secondary">Editar</a>
                    <asp:Button runat="server" Text="Baja" CssClass="btn btn-sm btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
