<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="RestoWeb.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">

        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-6">

                <div class="card shadow border-0">
                    <div class="card-body text-center p-5">

                        <div class="mb-4">
                            <span style="font-size: 70px;">⚠️</span>
                        </div>

                        <h2 class="fw-bold text-danger mb-3">
                            Ocurrió un error
                        </h2>

                        <p class="text-muted mb-4">
                            No se pudo completar la operación solicitada.
                            Por favor, intentá nuevamente o volvé al inicio.
                        </p>

                        <asp:Panel ID="pnlDetalle" runat="server" Visible="false" CssClass="alert alert-warning text-start">
                            <strong>Detalle:</strong>
                            <br />
                            <asp:Label ID="lblDetalleError" runat="server"></asp:Label>
                        </asp:Panel>

                        <div class="d-flex justify-content-center gap-2 mt-4">

                            <asp:Button 
                                ID="btnVolver" 
                                runat="server" 
                                Text="Volver" 
                                CssClass="btn btn-secondary px-4"
                                OnClick="btnVolver_Click" />

                            <asp:Button 
                                ID="btnInicio" 
                                runat="server" 
                                Text="Ir al inicio" 
                                CssClass="btn btn-dark px-4"
                                OnClick="btnInicio_Click" />

                        </div>

                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
