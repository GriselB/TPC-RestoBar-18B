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


    <div class="row">
        <div class="col-md-3 mb-3">
            <div class="card p-3 text-center bg-success text-white">
                <h6 class="fw-bold">Mesa 1</h6>
                <span style="font-size:12px;">Libre</span>
                <small>Sin asignar</small>
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <div class="card p-3 text-center bg-danger text-white">
                <h6 class="fw-bold">Mesa 2</h6>
                <span style="font-size:12px;">Ocupada</span>
                <small>Aureliano Michilini</small>
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <div class="card p-3 text-center bg-success text-white">
                <h6 class="fw-bold">Mesa 3</h6>
                <span style="font-size:12px;">Libre</span>
                <small>Grisel Bonadies</small>
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <div class="card p-3 text-center bg-danger text-white">
                <h6 class="fw-bold">Mesa 4</h6>
                <span style="font-size:12px;">Ocupada</span>
                <small>Maxi Programa</small>
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <div class="card p-3 text-center bg-success text-white">
                <h6 class="fw-bold">Mesa 5</h6>
                <span style="font-size:12px;">Libre</span>
                <small>Regina Laurentino</small>
            </div>
        </div>
        <div class="col-md-3 mb-3">
            <div class="card p-3 text-center bg-secondary text-white" style="opacity:0.4;">
                <h6 class="fw-bold">Mesa 6</h6>
                <span style="font-size:12px;">Sin asignar</span>
                <small>Otro mesero</small>
            </div>
        </div>
    </div>

</asp:Content>