using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PurplecometWebpage.DTO;
using PurplecometWebpage.DAO;
using PurplecometWebpage.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PurplecometWebpage
{
    /**
     * Se encarga de recibir los registros de datos de la aplicacion de escritorio.
     * Esta pagina no debe poseer ningun tipo de interfaz pues la respuesta debe ser definida de manera interna
     * para el correcto funcionamiento del sistema
     */
    public partial class AgentLogger : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            try
            {
                string username = Request.Params["username"];
                string password = Request.Params["password"];
                string log = Request.Params["log"];

                User usr = UserDAO.Login(username, password);

                if (usr == null)
                {
                    Response.Write("INVALID USER");
                    Response.End();
                }
                    
                Report report = new Report();
                report.Log = log;
                report.User_fk = usr.Id;

                ReportDAO.AddReport(report);
                Response.Write("success");
            }
            catch (Exception ex)
            {
                Response.Write("THERE WAS A CRASH LOGGING");
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}