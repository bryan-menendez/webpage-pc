<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleDetails.aspx.cs" Inherits="PurplecometWebpage.ScheduleDetails" %>
<%@ Import Namespace="PurplecometWebpage.DTO" %>
<%@ Import Namespace="PurplecometWebpage.DAO" %>
<%@ Import Namespace="System.Diagnostics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal runat="server" ID="ltMsg"></asp:Literal>
    <br />
    <h3>Horario</h3>
    <br />
    <br />
    <label id="lblId" runat="server">Id:</label> <asp:TextBox runat="server" ID="boxID" Text=""></asp:TextBox> <br />
    <label>Nombre del horario</label> <asp:TextBox runat="server" ID="boxNombre"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvNombre" ControlToValidate="boxNombre" ErrorMessage="Ingrese un nombre" ></asp:RequiredFieldValidator>
    <br />
    <label>Descripcion</label> <asp:TextBox runat="server" ID="boxDescripcion"></asp:TextBox> <br />
    <label runat="server" id="lblInst">Institucion:</label> 
    <asp:DropDownList name="selInstitution" id="selInstitution" runat="server">
    </asp:DropDownList>
    <br />
    <br />

    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col"></th>
                <th scope="col">Hora de entrada</th>
                <th scope="col">Hora de salida</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Lunes</td>
                <td><asp:TextBox runat="server" ID="boxLunesin"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="boxLunesout"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Martes</td>
                <td><asp:TextBox runat="server" ID="boxMartesin"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="boxMartesout"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Miercoles</td>
                <td><asp:TextBox runat="server" ID="boxMiercolesin"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="boxMiercolesout"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Jueves</td>
                <td><asp:TextBox runat="server" ID="boxJuevesin"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="boxJuevesout"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Viernes</td>
                <td><asp:TextBox runat="server" ID="boxViernesin"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="boxViernesout"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Sabado</td>
                <td><asp:TextBox runat="server" ID="boxSabadoin"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="boxSabadoout"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Domingo</td>
                <td><asp:TextBox runat="server" ID="boxDomingoin"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="boxDomingoout"></asp:TextBox></td>
            </tr>
        </tbody>
    </table>


    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click"/>
    <br /><br />
    <a href="~/ScheduleList" class="btn btn-secondary my-2 my-sm-0" runat="server">Volver</a>
</asp:Content>
