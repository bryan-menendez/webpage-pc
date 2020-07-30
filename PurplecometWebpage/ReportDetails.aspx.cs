using PurplecometWebpage.DAO;
using PurplecometWebpage.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurplecometWebpage
{
    public partial class ReportDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    User sUser = (User)Session["user"];

                    if (sUser == null) //logged user?
                    {
                        Response.Redirect("~/Login");
                        Context.ApplicationInstance.CompleteRequest();
                    }

                    if (String.IsNullOrEmpty(Request["Id"])) //has no id?
                        Response.Redirect("~/UserList"); //gtfo

                    Report report = ReportDAO.GetReport(int.Parse(Request["id"]));

                    if (report == null)
                        Response.Redirect("~/UserList");

                    User user = UserDAO.GetUser(report.User_fk);

                    ltVolver.Text = "<a href=\"/UserDetails?id=" + report.User_fk + "\" class=\"btn btn-secondary my-2 my-sm-0\">Volver</a>";
                    ltNombre.Text = user.Name + " " + user.Appat + " " + user.Apmat;
                    ltFecha.Text = report.Date.ToString("dd-MM-yyyy");
                    ltChars.Text = report.Charcount().ToString();
                    ltWords.Text = report.Wordcount().ToString();
                    ltLog.Text = report.Log;
                    ltLog.Text = Regex.Replace(ltLog.Text, @"\r\n?|\n", "<br />");

                    //if (sUser.Institution )
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }
    }
}