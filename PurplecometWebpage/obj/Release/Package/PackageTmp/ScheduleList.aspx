<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScheduleList.aspx.cs" Inherits="PurplecometWebpage.ScheduleList" %>
<%@ Import Namespace="PurplecometWebpage.DTO" %>
<%@ Import Namespace="PurplecometWebpage.DAO" %>
<%@ Import Namespace="System.Diagnostics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Lista de horarios</h3>
    <br />
    <a href="~/ScheduleDetails" class="btn btn-secondary my-2 my-sm-0" runat="server">Nuevo horario</a>
    <br />
    
    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Institucion</th>
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

                    if (Session["user"] != null)
                    {
                        User suser = (User)Session["user"];

                        if (suser.Type == "admin")
                            institutions = InstitutionDAO.GetInstitutions();
                        if (suser.Type == "manager")
                            institutions.Add(InstitutionDAO.GetInstitution(suser.Institution.Id));
                    }

                    //print schedules per instituion, in order
                    //if no institution or unknown, schedules wont show unless institution is reactivated
                    foreach (Institution inst in institutions)
                    {
                        List<Schedule> schedules = ScheduleDAO.GetSchedulesByInstitution(inst.Id);

                        foreach(Schedule schedule in schedules)
                        {
                            Response.Write("<tr>");
                            Response.Write("<th scope=\"row\">" + schedule.Id + "</th>");
                            Response.Write("<td>" + schedule.Name + "</td>");
                            Response.Write("<td>" + inst.Name + "</td>");
                            Response.Write("<td><a href=\"/ScheduleDetails?id=" + schedule.Id + "\">VER</a></td>");
                            Response.Write("</tr>");
                        }
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
