<%@ Page Title="Detalles de institucion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstitutionDetails.aspx.cs" Inherits="PurplecometWebpage.InstitutionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Institucion</h3>

    <asp:Literal runat="server" ID="ltMsg"></asp:Literal>
    <br /><br />
    <label id="lblId" runat="server">Id:</label> <asp:TextBox runat="server" ID="boxID" Text=""></asp:TextBox> <br />
    <label>Nombre:</label> <asp:TextBox runat="server" ID="boxNombre"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvNombre" ControlToValidate="boxNombre" ErrorMessage="Ingrese un nombre" ></asp:RequiredFieldValidator>
    <br />
    <label>Descripcion:</label> <asp:TextBox runat="server" ID="boxDescripcion"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvDescripcion" ControlToValidate="boxDescripcion" ErrorMessage="Ingrese una descripcion" ></asp:RequiredFieldValidator>
    <br />
    <label>Notas:</label> <asp:TextBox runat="server" ID="boxNotas"></asp:TextBox>
    <br />  
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click"/>
    <br /><br />
    <a href="~/InstitutionList" class="btn btn-secondary my-2 my-sm-0" runat="server">Volver</a>
</asp:Content>
