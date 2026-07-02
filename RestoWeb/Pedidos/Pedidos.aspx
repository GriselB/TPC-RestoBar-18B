<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="RestoWeb.Pedidos.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-3">
        <h4>Pedidos</h4>
    </div>
    <div class="card mb-3">
    <div class="card-body">

        <div class="row g-2 align-items-end">

            <div class="col-md-3">
                <label class="form-label">Desde</label>
                <asp:TextBox 
                    ID="txtDesde" 
                    runat="server" 
                    CssClass="form-control" 
                    TextMode="DateTimeLocal">
                </asp:TextBox>
            </div>

            <div class="col-md-3">
                <label class="form-label">Hasta</label>
                <asp:TextBox 
                    ID="txtHasta" 
                    runat="server" 
                    CssClass="form-control" 
                    TextMode="DateTimeLocal">
                </asp:TextBox>
            </div>

            <div class="col-md-2">
                <label class="form-label">Mesa</label>
                <asp:DropDownList 
                    ID="ddlMesa" 
                    runat="server" 
                    CssClass="form-select">
                </asp:DropDownList>
            </div>

            <div class="col-md-2">
                <label class="form-label">Mesero</label>
                <asp:DropDownList 
                    ID="ddlMesero" 
                    runat="server" 
                    CssClass="form-select">
                </asp:DropDownList>
            </div>

            <div class="col-md-2">
                <label class="form-label">Estado</label>
                <asp:DropDownList 
                    ID="ddlEstado" 
                    runat="server" 
                    CssClass="form-select">

                    <asp:ListItem Text="Todos" Value=""></asp:ListItem>
                    <asp:ListItem Text="Abiertos" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Cerrados" Value="0"></asp:ListItem>

                </asp:DropDownList>
            </div>

            <div class="col-md-2 mt-3">
                <asp:Button 
                    ID="btnBuscar" 
                    runat="server" 
                    Text="Buscar" 
                    CssClass="btn btn-dark w-100"
                    OnClick="btnBuscar_Click" />
            </div>

            <div class="col-md-2 mt-3">
                <asp:Button 
                    ID="btnLimpiar" 
                    runat="server" 
                    Text="Limpiar" 
                    CssClass="btn btn-secondary w-100"
                    OnClick="btnLimpiar_Click" />
            </div>

        </div>

    </div>
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