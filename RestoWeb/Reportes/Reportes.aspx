<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="RestoWeb.Reportes.Reportes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h4>Reportes</h4>

    <div class="row align-items-end mb-3">
    <div class="col-md-3">
            <label class="form-label">Nombre reporte</label>
            <asp:TextBox ID="txtNombreReporte"  runat="server" CssClass="form-control" />
        </div>
        <div class="col-md-3">
            <label class="form-label">Desde</label>
            <asp:TextBox  ID="txtDesde" runat="server"  CssClass="form-control" TextMode="Date" />
        </div>
        <div class="col-md-3">
            <label class="form-label">Hasta</label>
            <asp:TextBox ID="txtHasta" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
         <div class="col-md-1">
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-dark" />
       </div>
          </div>    
    <asp:GridView ID="dgvReportes" runat="server" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Mesa" DataField="Mesa" />
            <asp:BoundField HeaderText="Mesero" DataField="Mesero" />
            <asp:BoundField HeaderText="Apertura" DataField="Apertura" />
            <asp:BoundField HeaderText="Cierre" DataField="Cierre" />
            <asp:BoundField HeaderText="Total" DataField="Total" />
            
            
    </Columns>
</asp:GridView>
</asp:Content>