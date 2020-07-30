<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PurplecometWebpage.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2>Contactese con nostros</h2>
    <br />
    <br />
    <div>
        <label>Nombre: </label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="rfvNombre" ControlToValidate="txtNombre" ErrorMessage="Ingrese un nombre" ></asp:RequiredFieldValidator>
    </div>

    <div>
        <label>Email: </label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server" id="regexEmail" display="dynamic" ControlToValidate="txtEmail" ErrorMessage="Ingrese un email correcto" ValidationExpression="^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"> </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator runat="server" id="rfvEmail" ControlToValidate="txtEmail" display="dynamic" ErrorMessage="Ingrese un email" ></asp:RequiredFieldValidator>
    </div>

    <div>
        <label>Asunto: </label>
        <asp:TextBox ID="txtAsunto" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" id="rfvAsunto" ControlToValidate="txtAsunto" ErrorMessage="Ingrese un asunto" ></asp:RequiredFieldValidator>
    </div>
    <br />
    <div>
        <label>Mensaje </label> <br />
        <textarea ID="txtContenido" cols="20" runat="server"></textarea>
        <asp:RequiredFieldValidator runat="server" id="rfvContenido" ControlToValidate="txtContenido" ErrorMessage="Ingrese un mensaje" ></asp:RequiredFieldValidator>
    </div>

    <div>
        <asp:Button id="btnEnviarMensaje" runat="server" text="Enviar Mensaje" onclick="btnEnviarMensaje_Click"/>
    </div>

    <div>
        <asp:Literal id="ltMsg" runat="server"></asp:Literal>
    </div>

    
</asp:Content>
