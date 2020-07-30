<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageDetails.aspx.cs" Inherits="PurplecometWebpage.MessageDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Mensaje</h3>

    <asp:Literal runat="server" ID="ltMsg"></asp:Literal>
    <br /><br />
    <label id="lblId" runat="server">Id:</label> <asp:TextBox runat="server" ID="boxID" Text=""></asp:TextBox>
    <br />
    <label>Nombre:</label> <asp:TextBox runat="server" ID="boxNombre"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvNombre" ControlToValidate="boxNombre" ErrorMessage="Ingrese un nombre" ></asp:RequiredFieldValidator>
    <br />
    <label>Email:</label> <asp:TextBox runat="server" ID="boxEmail"></asp:TextBox>
    <asp:RegularExpressionValidator runat="server" id="regexEmail" display="dynamic" ControlToValidate="boxEmail" ErrorMessage="Ingrese un email correcto" ValidationExpression="^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"> </asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator runat="server" id="rfvEmail" ControlToValidate="boxEmail" display="dynamic" ErrorMessage="Ingrese un email" ></asp:RequiredFieldValidator>
    <br />
    <label>Asunto:</label> <asp:TextBox runat="server" ID="boxAsunto"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvAsunto" ControlToValidate="boxAsunto" ErrorMessage="Ingrese un asunto" ></asp:RequiredFieldValidator>
    <br />
    <label>Mensaje</label> <br /> <textarea runat="server" ID="boxContenido" style="width : 100%;"></textarea>
    <asp:RequiredFieldValidator runat="server" id="rfvContenido" ControlToValidate="boxContenido" ErrorMessage="Ingrese un mensaje" ></asp:RequiredFieldValidator>
    <br />
    
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click"/>
    <br /><br />
    <a href="~/MessageList" class="btn btn-secondary my-2 my-sm-0" runat="server">Volver</a>
</asp:Content>
