<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AutoForms.aspx.cs" Inherits="ProyectoDePracticaParaClases.AutoForms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="Margin col">
            <div class="mb-3">
                <label for="ModeloBox" class="form-label">Modelo</label>
                <asp:TextBox ID="ModeloBox" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="IDCarTextBox" class="form-label">Auto Id</label>
                <asp:TextBox ID="IDCarTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="DescripcionTextbox" class="form-label">Descripcion del Automotor</label>
                <asp:TextBox ID="DescripcionTextbox" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ListaCarga" class="form-label">Color</label>
                <asp:DropDownList ID="ListaCarga" CssClass="form-select" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="FechaBox" class="form-label">Fecha</label>
                <asp:TextBox ID="FechaBox" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <asp:CheckBox ID="CheckBox1" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Usado" CssClass="form-check-label"></asp:Label>
            <div class="mb-3">
                <asp:RadioButton ID="Nacional" runat="server" GroupName="Radios" Checked="true"/>
                <asp:Label ID="Label2" runat="server" Text="Nacional" CssClass="form-check-label"></asp:Label>
                <asp:RadioButton ID="Importado" runat="server" GroupName="Radios"/>
                <asp:Label ID="Label3" runat="server" Text="Importado" CssClass="form-check-label"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Button ID="AgregarBoton" runat="server" Text="Agregar Registro" OnClick="AgregarBoton_Click" CssClass="btn btn-primary"/>
                <asp:Button ID="ModificarBoton" Visible="false" runat="server" Text="Modificar Registro" OnClick="AgregarBoton_Click" CssClass="btn btn-primary btn-dark"/>
                <asp:Button ID="EliminarBoton" Visible="false" runat="server" Text="Eliminar Registro" OnClick="EliminarBoton_Click" CssClass="btn btn-primary btn-danger"/>
                <a href="Default.aspx">Volver</a>
            </div>
        </div>
        <div class="col-2"></div>
    </div>

</asp:Content>
