<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RestoWeb._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () {
            var mostrar = document.getElementById('<%= hfMostrarModal.ClientID %>').value;
            if (mostrar === '1') {
                var modal = new bootstrap.Modal(document.getElementById('modalConfirmarPedido'));
                modal.show();
            }
        };
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HiddenField ID="hfMostrarModal" runat="server" Value="0" />

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h4>Estado de mesas</h4>
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-secondary" OnClick="btnActualizar_Click" />
    </div>

    <asp:HiddenField ID="hfIdMesa" runat="server" />

    <asp:Repeater ID="repMesas" runat="server">
        <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col-md-3 mb-3">
                <asp:LinkButton
                    ID="btnMesa"
                    runat="server"
                    CommandArgument='<%# Eval("Id") %>'
                    CssClass="text-decoration-none"
                    CausesValidation="false"
                    OnClick="btnMesa_Click">
            <div class='<%# MesaTienePedido(Eval("Id")) ? "card p-3 text-center bg-danger text-white" : "card p-3 text-center bg-success text-white" %>' style="cursor:pointer;">
                <h6 class="fw-bold">Mesa <%# Eval("Numero") %></h6>
                <span style="font-size:12px;"><%# MesaTienePedido(Eval("Id")) ? "Ocupada" : "Libre" %></span>
                <small><%# Eval("Descripcion") %></small>
                <p class="card-text">
    Mesero: <%# ObtenerMeseroAsignado(Eval("Id")) %>
</p>
            </div>
                </asp:LinkButton>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

    <div class="modal fade" id="modalConfirmarPedido" tabindex="-1">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Abrir pedido</h5>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMesaSeleccionada" runat="server" />
                    ¿Desea abrir un nuevo pedido para esta mesa?
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarApertura" runat="server" Text="Sí, abrir pedido" CssClass="btn btn-dark" OnClick="btnConfirmarApertura_Click" />
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
