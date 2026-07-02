<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="RestoWeb.Pedidos.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-3">
        <h4>Pedidos</h4>
    </div>

    <asp:GridView 
        ID="dgvPedidos" 
        runat="server" 
        CssClass="table table-striped table-hover"
        AutoGenerateColumns="false"
        OnRowCommand="dgvPedidos_RowCommand">

        <Columns>

            <asp:BoundField HeaderText="N° Pedido" DataField="Id" />

            <asp:TemplateField HeaderText="Mesa">
                <ItemTemplate>
                    <%# Eval("Mesa.Numero") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Mesero">
                <ItemTemplate>
                    <%# Eval("Usuario.Nombre") %> <%# Eval("Usuario.Apellido") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField 
                HeaderText="Fecha apertura" 
                DataField="FechaApertura" 
                DataFormatString="{0:dd/MM/yyyy HH:mm}" />

            <asp:TemplateField HeaderText="Fecha cierre">
                <ItemTemplate>
                    <%# Eval("FechaCierre") == null ? "-" : Eval("FechaCierre", "{0:dd/MM/yyyy HH:mm}") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <%# Convert.ToBoolean(Eval("Activo")) ? "Abierto" : "Cerrado" %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:LinkButton 
                        ID="btnVer" 
                        runat="server" 
                        Text="Ver"
                        CssClass="btn btn-sm btn-dark"
                        CommandName="VerPedido"
                        CommandArgument='<%# Eval("Id") %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</asp:Content>