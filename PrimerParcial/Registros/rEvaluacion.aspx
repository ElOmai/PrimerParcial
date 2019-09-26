<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rEvaluacion.aspx.cs" Inherits="PrimerParcial.Registros.rEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--Fecha--%>
     <div class="col-md-2 col-md-offset-8">
        <asp:Label Text="Fecha" runat="server"/>
            <asp:TextBox ID="FechaTextBox" class="form-control input-sm" TextMode="Date" runat="server"></asp:TextBox>
     </div>
    <%--EvaluacionID--%>
    <div class="col-md-2 col-md-offset-3">
        <asp:Label ID="EvaluacionIDLabel" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="IDTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator" ValidationGroup="Buscar" ControlToValidate="IDTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <%--Buscar Button--%>
     <div class="col-md-2 col-sm-2 col-xs-2">
        <div class="input-group-append">
            <br />
                <asp:Button Text="Buscar" class="btn btn-primary" runat="server" ID="BuscarButton" OnClick="BuscarButton_Click1"/>
        </div>
     </div>
    <%--Estudiante--%>
    <div class="col-md-2 col-md-offset-3">
        <asp:Label ID="EstudianteLabel" runat="server" Text="Estudiante"></asp:Label>
        <asp:TextBox ID="EstudianteTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Buscar" ControlToValidate="EstudianteTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <%--Categoria--%>
    <div class="col-md-2 col-md-offset-3">
        <asp:Label ID="CategoriaLabel" runat="server" Text="Categoria"></asp:Label>
        <asp:TextBox ID="CategoriaTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Buscar" ControlToValidate="CategoriaTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <%--Valor--%>
    <div class="col-md-2 col-md-offset-3">
        <asp:Label ID="ValorLabel" runat="server" Text="Valor"></asp:Label>
        <asp:TextBox ID="ValorTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Buscar" ControlToValidate="ValorTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <%--Logrado--%>
    <div class="col-md-2 col-md-offset-3">
        <asp:Label ID="LogradoLabel" runat="server" Text="Valor"></asp:Label>
        <asp:TextBox ID="LogradoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Buscar" ControlToValidate="LogradoTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <%--Perdido--%>
    <div class="col-md-2 col-md-offset-3">
        <asp:Label ID="PerdidoLabel" runat="server" Text="Perdido"></asp:Label>
        <asp:TextBox ID="PerdidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Buscar" ControlToValidate="PerdidoTextBox" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
</asp:Content>
