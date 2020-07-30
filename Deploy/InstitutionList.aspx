<%@ Page Title="Lista de instituciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstitutionList.aspx.cs" Inherits="PurplecometWebpage.InstitutionList" %>
<%@ Import Namespace="PurplecometWebpage.DTO" %>
<%@ Import Namespace="PurplecometWebpage.DAO" %>
<%@ Import Namespace="System.Diagnostics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Lista de instituciones</h3>
    <br />
    <a href="~/InstitutionDetails" class="btn btn-secondary my-2 my-sm-0" runat="server">Nueva institucion</a>
    <br />
    
    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Nota</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
        <%
            try
            {
                if (!Page.IsPostBack)
                {
                    List<Institution> institutions = new List<Institution>();

                    if ((string)Session["usertype"] == "admin")
                        institutions = InstitutionDAO.GetInstitutions();

                    foreach (Institution inst in institutions)
                    {
                        Response.Write("<tr>");
                        Response.Write("<th scope=\"row\">" + inst.Id + "</th>");
                        Response.Write("<td>" + inst.Name + "</td>");
                        Response.Write("<td>" + inst.Notes + "</td>");
                        Response.Write("<td><a href=\"/InstitutionDetails?id=" + inst.Id + "\">VER</a></td>");
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