<%@ Page Title="Messages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs" Inherits="PurplecometWebpage.MessageList" %>
<%@ Import Namespace="PurplecometWebpage.DTO" %>
<%@ Import Namespace="PurplecometWebpage.DAO" %>
<%@ Import Namespace="System.Diagnostics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Lista de mensajes</h3>
    <br />
    <a href="~/MessageDetails" class="btn btn-secondary my-2 my-sm-0" runat="server">Nuevo Mensaje</a>
    <br />
    
    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Asunto</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
        <%
            try
            {
                if (!Page.IsPostBack)
                {
                    List<Message> messages = new List<Message>();

                    if ((string)Session["usertype"] == "admin")
                        messages = MessageDAO.GetMessages();

                    foreach (Message msg in messages)
                    {
                        Response.Write("<tr>");
                        Response.Write("<th scope=\"row\">" + msg.Id + "</th>");
                        Response.Write("<td>" + msg.Name + "</td>");
                        Response.Write("<td>" + msg.Subject + "</td>");
                        Response.Write("<td><a href=\"/MessageDetails?id=" + msg.Id + "\">VER</a></td>");
                        Response.Write("</tr>");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        %>
        </tbody>
    </table>
</asp:Content>
