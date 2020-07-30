<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PurplecometWebpage.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 class="display-3">Ingrese a la plataforma</h1>
        <hr class="my-4">

        <h5>Nombre de usuario</h5>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="rfvUsername" ControlToValidate="txtUsername" ErrorMessage="Ingrese un nombre de usuario" ></asp:RequiredFieldValidator>
        <br /><br /><br />
        
        <h5>Contraseña</h5>
        <asp:TextBox ID="txtPassword" type="password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="rfvPassword" ControlToValidate="txtPassword" ErrorMessage="Ingrese una contraseña" ></asp:RequiredFieldValidator>

        <br /> <br />
        <asp:Button id="btnLogin" runat="server" text="Ingresar" onclick="btnLogin_Click"/>

        <br />
        <div>
        <asp:Literal id="ltMsg" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
