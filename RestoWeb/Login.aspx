<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RestoWeb.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>RestoBar - Iniciar sesión</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-4">
                    <div class="card p-4">
                        <h4 class="mb-4 text-center">RestoBar</h4>
                        <h5 class="mb-4 text-center">Iniciar sesión</h5>
                        <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block" Visible="false" />
                        <div class="mb-3">
                            <label class="form-label">Usuario</label>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" />
                        </div>
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-dark w-100" OnClick="btnIngresar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>