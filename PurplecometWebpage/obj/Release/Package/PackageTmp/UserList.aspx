<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="PurplecometWebpage.UserList" %>
<%@ Import Namespace="PurplecometWebpage.DTO" %>
<%@ Import Namespace="PurplecometWebpage.DAO" %>
<%@ Import Namespace="System.Diagnostics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Lista de usuarios</h3>
    <br />
    <a href="~/UserDetails" class="btn btn-secondary my-2 my-sm-0" runat="server">Nuevo Usuario</a>
    <br />
    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Institucion</th>
                <th scope="col">Tipo</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <%
                
                List<User> users = new List<User>();
                User suser = (User) Session["user"];

                if ((string)Session["usertype"] == "admin")
                    users  = UserDAO.GetUsers();

                if ((string)Session["usertype"] == "manager")
                    users = UserDAO.GetUsersByInstitution(suser.Institution.Id);

                foreach (User user in users)
                {
                    Response.Write("<tr>");
                    Response.Write("<th scope=\"row\">" + user.Id + "</th>");
                    Response.Write("<td>" + user.Name + " " + user.Appat + " " + user.Apmat + "</td>");
                    Response.Write("<td>" + user.Institution.Name + "</td>");
                    Response.Write("<td>" + user.Type + "</td>");
                    Response.Write("<td><a href=\"/UserDetails?id=" + user.Id + "\">VER</a></td>");
                    Response.Write("</tr>");
                }
            %>
        </tbody>
    </table>
</asp:Content>
