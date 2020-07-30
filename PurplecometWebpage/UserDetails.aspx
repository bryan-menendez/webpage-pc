<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="PurplecometWebpage.UserDetails" %>
<%@ Import Namespace="PurplecometWebpage.DTO" %>
<%@ Import Namespace="PurplecometWebpage.DAO" %>
<%@ Import Namespace="System.Diagnostics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Detalles de Usuario</h3>

    <asp:Literal runat="server" ID="ltMsg"></asp:Literal>
    <br /><br />
    <a href="~/UserList" class="btn btn-secondary my-2 my-sm-0" runat="server">Volver</a>
    <br />
    <br />
    <label id="lblId" runat="server">Id:</label> <asp:TextBox runat="server" ID="boxID" Text=""></asp:TextBox> <br />
    <label>Nombre:</label> <asp:TextBox runat="server" ID="boxNombre"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvNombre" ControlToValidate="boxNombre" ErrorMessage="Ingrese un nombre" ></asp:RequiredFieldValidator>
    <br />
    <label>Apellido Paterno:</label> <asp:TextBox runat="server" ID="boxApPat"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvApPat" ControlToValidate="boxApPat" ErrorMessage="Ingrese un apellido paterno" ></asp:RequiredFieldValidator>
    <br />
    <label>Apellido Materno:</label> <asp:TextBox runat="server" ID="boxApMat"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" id="rfvApMat" ControlToValidate="boxApMat" ErrorMessage="Ingrese un apellido materno" ></asp:RequiredFieldValidator>
    <br />
    <label>Email:</label> <asp:TextBox runat="server" ID="boxEmail"></asp:TextBox>
    <asp:RegularExpressionValidator runat="server" id="regexEmail" display="dynamic" ControlToValidate="boxEmail" ErrorMessage="Ingrese un email correcto" ValidationExpression="^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"> </asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator runat="server" id="rfvEmail" ControlToValidate="boxEmail" display="dynamic" ErrorMessage="Ingrese un email" ></asp:RequiredFieldValidator>
    <br />
    <br />
    <label>Nombre de usuario:</label> <asp:TextBox runat="server" ID="boxUsername"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" display="dynamic" id="rfvUsername" ControlToValidate="boxUsername" ErrorMessage="Ingrese un username" ></asp:RequiredFieldValidator><br />
    <label>Contraseña:</label> <asp:TextBox runat="server" ID="boxPassword" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator runat="server" display="dynamic" id="rfvPassword" ControlToValidate="boxPassword" ErrorMessage="Ingrese una contraseña" ></asp:RequiredFieldValidator><br />
    <br />
    <label>Tipo de usuario:</label>
    <select name="selType" id="selType">
        <%
            if (!Page.IsPostBack)
            {
                List<string> types = UserDAO.GetUserTypes();
                User sUser = (User)Session["user"];
                User user = new User();

                if (!String.IsNullOrEmpty(Request["Id"]))
                {
                    user = UserDAO.GetUser(int.Parse(boxID.Text));
                }

                if (sUser.Type == "admin")
                {
                    foreach (string type in types)
                    {
                        if (!String.IsNullOrEmpty(Request["Id"]) && user.Type == type)
                            Response.Write("<option value=\"" + type + "\" selected>" + type + "</option>");

                        else
                            Response.Write("<option value=\"" + type + "\">" + type + "</option>");
                    }
                }
                else
                {
                    Response.Write("<option value=\"agent\">Agente</option>");
                }
            }
        %>
    </select>
    <br />
    <label runat="server" id="lblInst">Institucion:</label> 
    <asp:DropDownList name="selInstitution" id="selInstitution" runat="server">
    </asp:DropDownList> <br>
    <label>Horario:</label>
    <select name="selSchedule" id="selSchedule">
        <%
            if (!Page.IsPostBack)
            {
                List<Schedule> schedules = new List<Schedule>();
                User usr = new User();
                User sUser = (User)Session["user"];

                if (!String.IsNullOrEmpty(Request["Id"])) //mod
                {
                    int id = int.Parse(Request["id"]);
                    usr = UserDAO.GetUser(id);
                    schedules = ScheduleDAO.GetSchedulesByInstitution(usr.Institution.Id);
                }

                else if (sUser != null) //new
                {
                    if (sUser.Type == "admin")
                        schedules = ScheduleDAO.GetSchedules(); //allofthem

                    if (sUser.Type == "manager")
                        schedules = ScheduleDAO.GetSchedulesByInstitution(sUser.Institution.Id); //only those for the manager institution
                }

                foreach (Schedule sc in schedules)
                {
                    if (!String.IsNullOrEmpty(Request["Id"]) && usr.Schedule != null && sc.Id == usr.Schedule.Id) //not postback, requesting id info 
                        Response.Write("<option value=\"" + sc.Id + "\" selected>" +sc.Id + "-" +  sc.Name + "</option>");
                    else
                        Response.Write("<option value=\"" + sc.Id + "\">" +sc.Id + "-" +  sc.Name + "</option>");
                }
            }
        %>
    </select>
    <br /> <br />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click"/>
    <asp:Button ID="btnBorrar" runat="server" Text="Borrar usuario" OnClick="btnBorrar_Click"/>
    
    <br />
    <br /><br />

    <h3>Lista de reportes</h3>

    <table class="table table-hover">
        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Fecha (dia/mes/año)</th>
                <th scope="col"># palabras</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
        <%
            try
            {
                if (!Page.IsPostBack)
                {
                    if (!String.IsNullOrEmpty(Request["Id"]))
                    {
                        List<Report> reports = new List<Report>();
                        reports = ReportDAO.GetReportsByUser(int.Parse(Request["Id"]));

                        foreach (Report report in reports)
                        {
                            Response.Write("<tr>");
                            Response.Write("<th scope=\"row\">" + report.Id + "</th>");
                            Response.Write("<td>" + report.Date.ToString("dd-MM-yyyy") + "</td>");
                            Response.Write("<td>" + report.Words + "</td>");
                            Response.Write("<td><a href=\"/ReportDetails?id=" + report.Id + "&userid=" + Request["id"] + "\">VER</a></td>");
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

    <p>Los reportes marcados con una cantidad de palabras de -1 se encuentran en fase de recepcion de datos, y su conteo oficial sera entregado 24 horas despues de su registro inicial.</p>
</asp:Content>
