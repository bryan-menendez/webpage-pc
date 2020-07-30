<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportDetails.aspx.cs" Inherits="PurplecometWebpage.ReportDetails" %>
<%@ Import Namespace="PurplecometWebpage.DTO" %>
<%@ Import Namespace="PurplecometWebpage.DAO" %>
<%@ Import Namespace="System.Diagnostics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </br></br>
    <asp:Literal runat="server" id="ltVolver"></asp:Literal>
    </br></br>
    <div>
        <h2>Datos</h2>
    </div>
    <div>
        <label>Nombre: </label><asp:Literal id="ltNombre" runat="server"></asp:Literal><br />
        <label>Fecha: </label><asp:Literal id="ltFecha" runat="server"></asp:Literal><br />
        <label>Numero de caracteres: </label><asp:Literal id="ltChars" runat="server"></asp:Literal><br />
        <label>Numero de palabras: </label><asp:Literal id="ltWords" runat="server"></asp:Literal><br />
    </div>

    
    <br />
    <h3>Registro</h3><br />
    <p><asp:Literal id="ltLog" runat="server"></asp:Literal></p>
</asp:Content>
