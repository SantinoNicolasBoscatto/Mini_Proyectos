<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoDePracticaParaClases.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <style>
        .Oculto{
            display: none;
        }
    </style>--%>
    <div class="row">
        <div class="col-1"></div>
        <div class="col Margin">
            <asp:GridView ID="dgvAutos" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" CssClass="table table-dark" OnSelectedIndexChanged="dgvAutos_SelectedIndexChanged">
                <Columns>
<%--                    <asp:BoundField HeaderText="ID" DataField="Id" HeaderStyle-CssClass="Oculto" ItemStyle-CssClass="Oculto"/>--%>
                    <asp:BoundField HeaderText="Modelo De Auto" DataField="Modelo" />      
                    <asp:BoundField HeaderText="Color De Auto" DataField="Color" />
                    <asp:BoundField HeaderText="Descripcion De Auto" DataField="Descripcion" />
                    <asp:CheckBoxField HeaderText="Es importado?" DataField="Importado" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acciones" ControlStyle-CssClass="btn btn-primary btn-light"/>
                </Columns>
            </asp:GridView>
            <asp:Button ID="BotonAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-dark" OnClick="BotonAgregar_Click"/>
        </div>
        <div class="col-1"></div>
    </div>

</asp:Content>
