<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestoWeb._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4 class="mb-4">Estado de mesas</h4>

    <div class="row mb-4">
        <div class="col-md-3">
            <div class="card text-center p-3">
                <div class="text-muted" style="font-size:12px;">Total de mesas</div>
                <div class="fs-4 fw-bold">6</div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-center p-3">
                <div class="text-muted" style="font-size:12px;">Mesas libres</div>
                <div class="fs-4 fw-bold text-success">3</div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-center p-3">
                <div class="text-muted" style="font-size:12px;">Mesas ocupadas</div>
                <div class="fs-4 fw-bold text-danger">2</div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card text-center p-3">
                <div class="text-muted" style="font-size:12px;">Pedidos abiertos</div>
                <div class="fs-4 fw-bold text-warning">2</div>
            </div>
        </div>
    </div>


<asp:Repeater ID="repMesas" runat="server" OnItemCommand="repMesas_ItemCommand">
    <HeaderTemplate>
        <div class="row">
    </HeaderTemplate>

    <ItemTemplate>
        <div class="col-md-3 mb-3">
            <asp:LinkButton 
                ID="btnMesa" 
                runat="server"
                CommandName="SeleccionarMesa"
                CommandArgument='<%# Eval("Id") %>'
                CssClass="text-decoration-none"
                CausesValidation="false">

                <div class="card p-3 text-center bg-success text-white" style="cursor:pointer;">
                    <h6 class="fw-bold">Mesa <%# Eval("Numero") %></h6>
                    <span style="font-size:12px;">Libre</span>
                    <small><%# Eval("Descripcion") %></small>
                </div>

            </asp:LinkButton>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>

</asp:Content>